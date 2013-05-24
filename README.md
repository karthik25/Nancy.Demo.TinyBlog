Read ME!
----------

tiny_Blog is a very simple blogging system, This is a new approach to blogging and so here, you don't 
go through the troubles of creating a post with the help of add/edit/manage pages. To create a post just 
create a .yml file within the <b>Posts</b> folder! 

It should use the following format - there should be a "title", "date_created", 
"date_edited", "content" and "tags"! That's it!!! The file name will act as the url :) So, if the file name
is "Lorem Ipsum Dolor.yml", the url will be "http://&lt;base_url&gt;/blog/lorem-ipsum-dolor" !

For more information about YAML, refer the wikipedia page: http://en.wikipedia.org/wiki/Yaml. Given below is a
sample YAML file.

########################################################################################
---
title: Lorem Ipsum Dolor
date_created: 2013-05-18
date_edited: 2013-05-18
content: Lorem ipsum dolor sit amet, consectetur <b>adipiscing</b> elit. Sed orci ante, tincidunt vitae hendrerit.
tags:
    - ASP.Net
    - C#
    - IronRuby
########################################################################################
