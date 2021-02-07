


$(document).ready(() => {
    $('.dropdown-trigger').dropdown();

})

$(".addSReasonR").on("click", e => {
    var modal = $("#referModal");
    var obj = $(e.target);
    $("#referModalTitle").html("Добавление справки. Cтудента : " + obj.attr('value'))
    var content = "";
    content += "Семестр : ";
    content += `<label style="margin-right: 15px"><input name="semester" class="semester" onclick="changeM(1)" type="radio" value="1" /><span>1</span></label>`
    content += `<label style="margin-right: 15px"><input name="semester" class="semester" onclick="changeM(2)" type="radio" value="2" /><span>2</span></label>`
    content += "<br />";
    content += '<div id="sM"></div>';
    content += '<div style="height:90%" class="row"><div class="input-field col s12"><input id="count" name="count" type="number" class="validate"><label for="count">Количество</label></div></div>'
    content += '<div class="file-field input-field"><div class="btn"><span>Файл</span><input type="file" id="files" name="files"></div><div class="file-path-wrapper"><input class="file-path validate" type="text" placeholder="Выберите файл"></div></div>'
    var hidden = '<input type="hidden" name="Id" value="' + obj.attr('key') + '" / >'
    var course = '<input type="hidden" name="Id" value="' + obj.attr('cc') + '" / >'
    modal.html(content + hidden)
})








