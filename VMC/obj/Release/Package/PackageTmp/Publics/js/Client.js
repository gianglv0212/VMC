function playvideo(e) {
    var stream = e.getAttribute("data-stream");

    //var id = e.getAttribute("data-id");
    //create video tag
    var video = document.createElement('video');
    //video.setAttribute("id", id);
    video.setAttribute("height", "90");
    video.setAttribute("width", "160");
    video.setAttribute("controls", "");
    video.setAttribute("autoplay", "");
    e.appendChild(video);
    //create source tag
    var source = document.createElement('source');
    source.setAttribute("src", stream);
    source.setAttribute('type', 'video/mp4');
    var child = e.children[0];
    child.appendChild(source);
    e.removeAttribute("onclick");
    e.removeAttribute("class");

}
$(document).ready(function () {
    var popOpts = {
        placement: 'top',
        title: 'Bạn có chắc chắn muốn xóa không?',
        html: 'true',
        content: '<button id="cfm-yes" class="btn btn-sm btn-danger" type="button"><span class="glyphicon glyphicon-trash"></span>Xác nhận</button><button id="cfm-no" class="btn btn-sm btn-default" type="button"><span class="glyphicon glyphicon-remove-circle "></span>Hủy bỏ</button>',
        popout: 'true',
    }


    // Delete button popover confirmation
    $(".btn-delete").popover(popOpts).on('shown.bs.popover', function (e) {
        
        var $delete = $(this)
        var $form = $delete.closest('form')
        var $pop = $form.find('.popover');
        var $popButtons = $pop.find('button').click(function () {
            if ($(this).is('#cfm-yes')) {
                $delete.popover('destroy').popover(popOpts);
            }else
            {
                $delete.popover('destroy').popover(popOpts);
            }
            

        });

    });
});
