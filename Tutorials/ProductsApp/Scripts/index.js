var uri = 'api/products';

function formatItem(item) {
    return item.Name + ': $' + item.Price;
}

$(document).ready(function () {

    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#products'));
            });
        });

    // Configure Page Events
    $('#searchButton').click(function () {
        find();
    });
});


function find() {
    var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#product').text(formatItem(data));
        })
        .fail(function (jqXhr, textStatus, err) {
            $('#product').text('Error: ' + err);
        });
}

