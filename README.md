# AngelASPExtentions
A set of Extention Methods that allow for easy bundling from anywhere and razor templating to a string. Maybe Template a Email using razor?

This Is a ASP extention lib for ASP MVC Controllers and ASP MVC Razor HTML helper.

For your controller
 -There is an extention for Razor Templating into a string. Use full for emails etc.
 -There are extentions for adding prebundled script and style bundles va the controller. I wouldnt recomend using these as there at HTML helper vs. that are better in practice
 
For your HTMLHelper for Razor
  -There are extentions for adding bundles from any page and one for rendering from the head. useful if you want styles perpage or scripts
  -There is one for rendering them as well
  
For Strings there is a single extention :-)

There is also a Result class called OpenStringResult. Its more there to extend as it is just used with the Razor template extention.


For the Razor DLL you must go to apps web.config in Views the view folder and add to the 
\<assemblies\> and add \<add assembly="AngelASPExtentions, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" /\>. 
Then in \<namespaces\> add \<add namespace="AngelASPExtentions.ASPMVCRazorHTMLHelperExtentions" /\>
