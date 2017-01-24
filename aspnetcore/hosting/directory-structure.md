---
title: Directory Structure | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: e55eb131-d42e-4bf6-b130-fd626082243c
ms.technology: aspnet
ms.prod: aspnet-core
uid: hosting/directory-structure
---
# Directory structure

<a name=directory-structure></a>

By [Luke Latham](https://github.com/GuardRex)

In ASP.NET Core, the application directory, *publish*, is comprised of application files, config files, static assets, packages, and the runtime (for self-contained apps). This is the same directory structure as previous versions of ASP.NET, where the entire application lives inside the web root directory.

|App Type|Directory Structure|
|---|---|
|Portable|<ul><li>publish\*<ul><li>logs\* (if included in publishOptions)</li><li>refs\*</li><li>runtimes\*</li><li>Views\* (if included in publishOptions)</li><li>wwwroot\* (if included in publishOptions)</li><li>.dll files</li><li>myapp.deps.json</li><li>myapp.dll</li><li>myapp.pdb</li><li>myapp.PrecompiledViews.dll (if precompiling Razor Views)</li><li>myapp.PrecompiledViews.pdb (if precompiling Razor Views)</li><li>myapp.runtimeconfig.json</li><li>web.config (if included in publishOptions)</li></ul></li></ul>|
|Self-contained|<ul><li>publish\*<ul><li>logs\* (if included in publishOptions)</li><li>refs\*</li><li>Views\* (if included in publishOptions)</li><li>wwwroot\* (if included in publishOptions)</li><li>.dll files</li><li>myapp.deps.json</li><li>myapp.exe</li><li>myapp.pdb</li><li>myapp.PrecompiledViews.dll (if precompiling Razor Views)</li><li>myapp.PrecompiledViews.pdb (if precompiling Razor Views)</li><li>myapp.runtimeconfig.json</li><li>web.config (if included in publishOptions)</li></ul></li></ul>|
\* Indicates a directory

The contents of the *publish* directory represent the *content root path*, also called the *application base path*, of the deployment. Whatever name is given to the *publish* directory in the deployment, its location serves as the server's physical path to the hosted application. The *wwwroot* directory, if present, only contains static assets. The *logs* directory may be included in the deployment by creating it in the project and adding it to **publishOptions** of *project.json* or by physically creating the directory on the server.

The deployment directory requires Read/Execute permissions, while the *logs* directory requires Read/Write permissions. Additional directories where assets will be written require Read/Write permissions.
