# ajax-data-table
A lightweight JavaScript library to generate HTML data tables on-the-fly, fast, easy to use, bootstrap supported and easy to customize.

Initially, ajax-data-table was created to use in SiteEngine, a private e-commerce platform. During the development, ajax-data-table is now very flexible and can help developers to create HTML tables quickly and easily.

## Features
- Lightweight and fast
- Bootstrap support
- AJAX data loading
- Sorting and pagination
- Customizable cell renderers
- Bulk actions support
- Drag and drop row reordering
- Modern JavaScript (ES6+)

## Browser Compatibility
The library uses modern JavaScript features including:
- `let` and `const` for variable declarations
- Arrow functions
- Template literals
- Strict equality operators

Supports all modern browsers (Chrome, Firefox, Safari, Edge) and requires ES6 support.

## Quick Start

### Basic Usage
```html
<a id="my-table" href="/api/data" class="ajax-data-table"></a>
```

### With Options
```javascript
AjaxDataTable.render($("#my-table"), {
    width: "100%",
    onCellClicked: function(column_model, table_data, row_index) {
        console.log(table_data.data[row_index]);
    },
    page: 0 // Start at first page
});
```

## Demo
The project includes a demo ASP.NET Core application showcasing various features and usage examples.

To run the demo:
```bash
cd ajax-data-table-demo
dotnet run
```

Then navigate to `http://localhost:5000`
