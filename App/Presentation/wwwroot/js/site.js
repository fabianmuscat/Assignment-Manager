function closeMenuOn(...selectors) {
    $.each(selectors, (index, value) => {
        $(document).on('click', value, function(event) {
            $('.open').removeClass('opened').css('background-color', '#146c43');
            $('.open span').css('position', 'relative');

            $('.open span:nth-child(1)').css('top', '0');
            $('.open span:nth-child(3)').css('top', '0');
            event.stopPropagation();
        });
    })
}

$(document).ready(function() {
    $(document).on('click', '.open', function(event){
        $(this).addClass('opened');
        $(this).css('background', 'none');
        $('.open span').css('position', 'absolute');
        
        $('.open span:nth-child(1)').css('top', '15%');
        $('.open span:nth-child(3)').css('top', '75%');
        event.stopPropagation();
    });
    
    closeMenuOn('body', '.opened', '.cls');
});