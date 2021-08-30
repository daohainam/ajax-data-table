rd /S /Q

md build\lib\net
md build\lib\netstandard1.0 
md build\content\Scripts
md build\content\Content

copy ..\ajax-data-table\bin\Debug\ajax-data-table.dll build\lib\net
copy ..\ajax-data-table-models\bin\Debug\netstandard1.0\ajax-data-table.dll build\lib\netstandard1.0
copy ..\ajax-data-table-test\Scripts\ajax-data-table.js build\content\Scripts
copy ..\ajax-data-table-test\Content\ajax-data-table.css build\content\Content
copy ..\ajax-data-table-test\Content\ajax-data-table-icons.png build\content\Content
copy ..\ajax-data-table-test\Content\ajax-data-table-loader.gif build\content\Content

nuget pack Package.nuspec -BasePath build