/*
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 23,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To add a Validation for files that are uploaded to the client
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.net
//  Writer/Publisher: Microsoft
//  Link: https://www.asp.net/
//  },
//  {
//  Name: stackoverflow.com question 40199870 Answer 1
//  Writer/Publisher: Stephen Muecke answered Oct 23 '16 at 5:58
//  Link: https://stackoverflow.com/questions/40199870/how-to-validate-file-type-of-httppostedfilebase-attribute-in-asp-net-mvc-4?answertab=votes#tab-top
//  }
*/

//Bundle with jquery.validate.js and jquery.validate.unobtrusive.js
//to use FileSizeAttribute, FileTypeAttribute, and MaxFileNumAttribute

// This is to add file data annotation for the acceptable types of files
$.validator.unobtrusive.adapters.add('filetype', ['validtypes'], function (options)
{
    options.rules['filetype'] = { validtypes: options.params.validtypes.split(',') };
    options.messages['filetype'] = options.message;
});

$.validator.addMethod("filetype", function (value, element, param)
{
    for (var i = 0; i < element.files.length; i++)
    {
        var extension = getFileExtension(element.files[0].name);
        if ($.inArray(extension, param.validtypes) === -1)
        {
            return false;
        }
    }
    return true;
});

function getFileExtension(fileName)
{
    if (/[.]/.exec(fileName))
    {
        return /[^.]+$/.exec(fileName)[0].toLowerCase();
    }
    return null;
}

// This is to add file data annotation for the acceptable sizes of files
$.validator.unobtrusive.adapters.add('filetype', ['validtypes'], function (options)
{
    options.rules['filetype'] = { validtypes: options.params.validtypes.split(',') };
    options.messages['filetype'] = options.message;
});

$.validator.addMethod("filetype", function (value, element, param)
{
    for (var i = 0; i < element.files.length; i++)
    {
        var extension = getFileExtension(element.files[0].name);
        if ($.inArray(extension, param.validtypes) === -1)
        {
            return false;
        }
    }
    return true;
});

function getFileSize(fileName)
{
    var fileInput = document.getElementById("fUpload");
    if (window.ActiveXObject)
    {
        var fso = new ActiveXObject("Scripting.FileSystemObject");
        var filepath = document.getElementById('fileInput').value;
        var thefile = fso.getFile(filepath);
        var sizeinbytes = thefile.size;
        return sizeinbytes;
    } else
    {
        var sizeinbytes = document.getElementById('fileInput').files[0].size;
        return sizeinbytes;
    }
    return null;
}


// This is to add file data annotation for the acceptable number of files
$.validator.unobtrusive.adapters.add('filetype', ['validtypes'], function (options)
{
    options.rules['filetype'] = { validtypes: options.params.validtypes.split(',') };
    options.messages['filetype'] = options.message;
});

$.validator.addMethod("filetype", function (value, element, param)
{
    for (var i = 0; i < element.files.length; i++)
    {
        var extension = getFileExtension(element.files[0].name);
        if ($.inArray(extension, param.validtypes) === -1)
        {
            return false;
        }
    }
    return true;
});

function getFileExtension(fileName)
{
    var fileInput = document.getElementById("fUpload");
    return fileInput.files.length; // Size returned in bytes.
}