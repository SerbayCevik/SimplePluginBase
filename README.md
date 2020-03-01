# SimplePluginBase

*Makes it easy to create a simple plugin-based architecture 

## Motivation
Imagine you deploy an application with, say, a pipeline for converting,filtering and sorting from external source to some specific file format.
- this is a component to be used in the context of the xml converting.
- this is a component to be used in the context of the json converting.
- this is a component to be used in the context of the csv converting.

## Usage
A short overview:

```
registers ```XmlConverter``` as providing ```IExport``` in the context of *UniqueNameOfMyPlugin*.
registers ```CsvConverter``` as providing ```IExport``` in the context of *UniqueNameOfMyPlugin*.
registers ```JsonConverter``` as providing ```IExport``` in the context of *UniqueNameOfMyPlugin*.
```
For a complete example, see the ```Homework``` directory here at github.

## Scope Limitation
Sometimes you will want to load plugins dynamically, that is, upon deployment of the main application you do not yet know which plugins will be available. In such a case you will need to tell *PluginManagement* 
which assemblies to load. For example, load all assemblies in a ```Plugins``` folder somewhere in your local user data.

## Third-Party Libraries
-CsvHelper
