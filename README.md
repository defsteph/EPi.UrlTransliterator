#URL Transliteration for EPiServer CMS 10

##Usage
When generating URLs, EPiServer strips out all non-alphanumeric characters. 
This Add-On transliterates the proposed url segment before stripping, ensuring that urls for languages not using alphanumeric chars look nice.

For example, using the built-in URL Generator, the string "伤寒论 勘误" as a page name would give the url "-", since everything is stripped out, apart from the space.

Using this Add-On, the generated URL for "伤寒论 勘误" becomes "shang-han-lun-kan-wu".

## Release history

### Release 1.0.0
Initial release.

### Release 2.0.0
Now supports EPiServer CMS 11.
Added MIT License.