Read ME!
----------

<b>tiny_Blog</b> is a very simple blogging system using the Nancy framework, This is a new approach to blogging and so here, 
you don't go through the troubles of creating a post with the help of add/edit/manage pages. To create a post, just 
create a YAML (.yml) file within the <b>Posts</b> folder in the <b>Nancy.Demo.TinyBlog</b> web application's folder 
in your file system! So whenever you create a new post or modify (or delete) a post, you just have to copy over the 
updated files to the server hosting the application :)

It should use the following format - there should be a "title", "date_created", 
"date_edited", "content" and "tags"! That's it!!! The file name will act as the url :) So, if the file name
is "Lorem Ipsum Dolor.yml", the url will be "http://&lt;base_url&gt;/blog/lorem-ipsum-dolor" !

For more information about YAML, refer the wikipedia page: http://en.wikipedia.org/wiki/Yaml. Given below is a
sample YAML file.


```yaml
---
title: Lorem Ipsum Dolor
date_created: 2013-05-18
date_edited: 2013-05-18
content: Lorem ipsum dolor sit amet, consectetur <b>adipiscing</b> elit. Sed orci ante, tincidunt vitae hendrerit.
tags:
    - ASP.Net
    - C#
    - IronRuby
