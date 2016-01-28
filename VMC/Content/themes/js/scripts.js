
var paramtype = getQueryVariable("type");
var paramstatus = getQueryVariable("status");
var paramcate = getQueryVariable("cate");
var paramname = getQueryVariable("name");

function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) {
            return pair[1];
        }
    }
}

function vodCateSelect(url, e) {
    var cate = e.getAttribute("data-id");
    if (paramtype) url += '&type=' + paramtype;
    if (paramstatus) url += '&status=' + paramstatus;
    if (paramname) url += '&name=' + paramname;
    url += '&cate=' + cate;
    window.location = url;
}

function vodtypeSelect(url,type)
{
    if (paramcate) url += '&cate=' + paramcate;
    if (paramstatus) url += '&status=' + paramstatus;
    if (paramname) url += '&name=' + paramname;
    url += '&type=' + type;
    window.location = url;
}

function vodstatusSelect(url, status)
{
    $('#divStatus input[type=checkbox]').each(function () {
        if (this.checked) {
            paramStatus += paramStatus == '' ? $(this).val() : ',' + $(this).val();
        }
    });

    url += paramStatus == '' ? '' : 'status=' + paramStatus;

    if (paramcate) url += '&cate=' + paramcate;
    if (paramtype) url += '&type=' + paramtype;
    if (paramname) url += '&name=' + paramname;
    
    window.location = url;
}
function cateSelect(url, cate) {


    url += '&cate=' + cate;

    if (paramtype != '') {
        url += '&type=' + paramtype;
    }

    if (paramstatus != '') {
        url += "&status=" + paramstatus;
    }
    if (paramname) url += '&name=' + paramname;
    window.location = url;

};
function playvideo(e)
{
  var stream = e.getAttribute("data-stream");
  var id = e.getAttribute("data-id");
//create video tag
  var video = document.createElement('video');
  video.setAttribute("id", id);
  video.setAttribute("height", "100");
  video.setAttribute("width", "120");
  video.setAttribute("controls","");
  video.setAttribute("autoplay","");
  document.getElementById("output_"+id).appendChild(video);
  //create source tag
  var source = document.createElement('source');
  source.setAttribute("src", stream);
  source.setAttribute('type', 'video/mp4');
  document.getElementById(id).appendChild(source);
   $("#logo_"+id).remove();

  
}
function search_data()
{
  $("#cate").submit() 
}


function readURL(input,id,ouput) {
  var w = document.getElementById(id).getAttribute("Width"); 
  var h = document.getElementById(id).getAttribute("Height"); 
        if (input.files && input.files[0]) {
              $("#"+id).remove();
            var reader = new FileReader();

      var elem = document.createElement("img");
      elem.setAttribute("id", id);
      elem.setAttribute("height", h);
      elem.setAttribute("width", w);
      elem.setAttribute("onclick", "awremove('"+id+"','"+ouput+"');");
      
      document.getElementById(ouput).appendChild(elem);
            reader.onload = function (e) {
                $("#"+id)
                    .attr('src', e.target.result)
                    .attr('title',input.files[0].name);
            };
            reader.readAsDataURL(input.files[0]);  
        }
}
function awremove(id,ouput)
{
    $("#" + id).attr('src', "/Uploads/Core/noimg.jpg");
  document.getElementById(id+"input").value = "";
}
function video(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            var n = $( "#output video" ).length;
            var i = n+1;
            var elem = document.createElement("video");
      elem.setAttribute("id", "video"+i);
      elem.setAttribute("height", "200");
      elem.setAttribute("width", "200");
      elem.setAttribute("controls","");
      //elem.setAttribute("onclick", "awremove(this);");
      
      document.getElementById("output").appendChild(elem);
            reader.onload = function (e) {
                $('#video'+i)
                    .attr('src', e.target.result)
                    .attr('title',input.files[0].name)
                    .attr('data-size',input.files[0].size);
            };
            reader.readAsDataURL(input.files[0]);  
        }
}

//filter status
var status = '1';
var paramStatus = '';

function statusSelect(url) {
    paramStatus = '';
    $('#divStatus input[type=checkbox]').each(function () {
        if (this.checked) {
            paramStatus += paramStatus == '' ? $(this).val() : ',' + $(this).val();
        }
    });
    url += '?';
    url += paramStatus == '' ? '' : 'status=' + paramStatus;
    window.location = url;
}