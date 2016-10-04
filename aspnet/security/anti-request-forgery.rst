Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core
==========================================================================

`Fiyaz Hasan <https://twitter.com/FiyazBinHasan>`__, David Paquette

See this `word document <https://www.dropbox.com/sh/jfmncpp0z79m9mt/AAAAB98zC4J7f9g_l6egU8nta?dl=0>`__ and `Evolving ASP.NET Apps–Cookie Authentication <https://blogs.msdn.microsoft.com/cdndevs/2015/02/18/evolving-asp-net-appscookie-authentication/>`__ 

David Paquette gave me permission to copy his blog if we add him to the authors list.

Cross-site request forgery (also known as XSRF or CSRF) is an attack against web-hosted applications whereby a malicious web site can influence the interaction between a client browser and a web site trusted by that browser. These attacks are made possible because web browsers send authentication tokens automatically with every request to a web site.

Here is an example of a CSRF attack:

#. A user logs into ``www.example.com``, using forms authentication.
#. The server authenticates the user and issues a  response that includes an authentication cookie.
#. The attacker uses social engineering to trick the user into clicking on a link to a malacious site.

  This malicious site contains the following HTML form:

.. code-block:: html

   <h1>You Are a Winner!</h1>
     <form action="http://example.com/api/account" method="post">
       <input type="hidden" name="Transaction" value="withdraw" />
       <input type="hidden" name="Amount" value="1000000" />
     <input type="submit" value="Click Me"/>
   </form>

Notice that the form action posts to the vulnerable site, not to the malicious site. This is the “cross-site” part of CSRF.

4. The user clicks the submit button. The browser includes the authentication cookie with the request.
5. The request runs on the server with the user’s authentication context, and can do anything that an authenticated user is allowed to do.

Although this example requires the user to click the form button, the malicious page could just as easily run a script that sends an AJAX request. Moreover, using SSL does not prevent a CSRF attack, because the malicious site can send an “https://” request.

Typically, CSRF attacks are possible against web sites that use cookies for authentication, because browsers send all relevant cookies to the destination web site. However, CSRF attacks are not limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user logs in with Basic or Digest authentication. the browser automatically sends the credentials until the session ends.

IAntiforgery
-----------------

``IAntiforgery`` provides access to the antiforgery system and is exposed in the ``Configure`` method of the ``Startup`` class:

.. code-block:: c#

  public void Configure(IApplicationBuilder app, IAntiforgery antiforgery)

IAntiforgeryAdditionalDataProvider 
----------------------------------

The ``IAntiForgeryAdditionalDataProvider`` type allows developers to extend the behavior of the anti-XSRF system by round-tripping additional data in each token. The ``GetAdditionalData`` method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call ``ValidateAdditionalData`` to validate this data when the token is validated.


Fundamentals
--------------

Cookie based authentication
^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Once a user has authenticated using their username and password, they are issued a token that can be used to identify them and validate that they have been authenticated. The token is stored as a cookie that accompanies every request the client makes. Generating and validating this cookie is done by the OWIN Cookie Authentication middleware. ASP.NET Core provides cookie :ref:`middleware <fundamentals-middleware>` which serializes a user principal into an encrypted cookie and then, on subsequent requests, validates the cookie, recreates the principal and assigns it to the ``User`` property on ``HttpContext``. 

When cookie  is used, 
The authentication cookie is just a container for the forms authentication ticket. The ticket is passed as the value of the forms authentication cookie with each request and is used by forms authentication, on the server, to identify an authenticated user. 


When a user is logged in to a system, a user session is created on the server side and it is stored in the database or in some kind of in-memory storage systems. The system generates a session key that points to the actual session in the database and it is attached to a client side cookie. After that every time when a user asks for a page which needs authorization, the session key in the cookie is finds the appropriate user session in the database. Then the system checks if the user from whom the user session is stored has the privilege to access that page. If it does, then eventually the application takes the user to that page. As you can see we are using cookies to make the application stateful.
USERTOKENS
Token based authentication on the other hand doesn’t store any kind of session in the database. Instead when a user is logged in he is issued with a token (not antiforgery token). This token is self-contained. It contains all the data that is required to validate the token as well as user information through claims. When a user wants to access some authorized pages the token is send to the server with an additional authorization header in form of Bearer {token} (Recall from previous web api applications with single user authentication enabled). This makes the application stateless since in every subsequent request the token is passed in the request for server side validation. One thing to remember is this token is not encrypted rather it is encoded. On the server side the token can be decoded to have the raw information about the token.  
To send the token in subsequent requests, you can either store it in browser’s local storage or in a cookie. You don’t have to worry about anything related to XSRF if your token is stored in the local storage. But you have to deal with XSRF if you store it in a cookie. 


Multiple applications are hosted in one domain
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Even though ``example1.cloudapp.net`` and ``example2.cloudapp.ne``t are different hosts, there is an implicit trust relationship between all hosts under the ``*.cloudapp.net`` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other’s cookies (the same-origin policies that govern AJAX requests do not necessarily apply to HTTP cookies). The ASP.NET Core runtime provides some mitigation in that the username is embedded into the field token, so even if a malicious subdomain is able to overwrite a session token it will be unable to generate a valid field token for the user. However, when hosted in such an environment the built-in anti-XSRF routines still cannot defend against session hijacking or login XSRF attacks.





Additional Resources
^^^^^^^^^^^^^^^^^^^^^^


- `XSRF <https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)>`__ on `Open Web Application Security Project <https://www.owasp.org/index.php/Main_Page>`__ (OWASP).