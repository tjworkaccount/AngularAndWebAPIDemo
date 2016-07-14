function submit() {
    $("form").submit();
}

function pageSelected(page) {
    $('#Page').val(page);
    submit();
}

function previous() {
    pageSelected(parseInt($('#Page').val()) - 1);
}

function next() {
    pageSelected(parseInt($('#Page').val()) + 1);
}