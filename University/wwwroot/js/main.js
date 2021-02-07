const sSideB = $("#secondarySideBar")
const title = $("#title")
const report = $("#report")


var sSem = [
    "Февраль",
    "Март",
    "Апрель",
    "Май",
    "Июнь"
];

var fSem = [
    "Сентябрь",
    "Октябрь",
    "Ноябрь",
    "Декабрь"
]


let grId = 0;
let grEduStart = 0;
let reportHref;
let setSkipHref;
function Modal(id, eduStart) {
    grId = id;
    grEduStart = eduStart
    reportHref = '/Skip/Report?id=' + id + '&eduYear=' + $("#hidden").attr("value") + '&semester=' + $("#hidden").attr("ss");

    $("#skipT").attr("href", '/Skip/getTemplate/' + id);
    let select = ""
    $.ajax({
        url: "/Group/getById/" + id,
        method: "Get",
        contentType: "Json",
        success: data => {
            if (data.course <= data.EduDuration === false) {
                $("#title").html("Группа : " + data.name)
            } else {
                $("#title").html("Группа : " + data.name + '<span style="font-size: 12px" > (Обучение завершено) </span>')
            }
            $("#addSkipLable").html("Форма для добавления пропусков в группу : " + data.name + `  <a id="skipT"  style="font-size: 12px;" href="/Skip/getTemplate/${data.id}">( Скачать шаблон )</a>`);
            select += `<input type="hidden" name="groupId" id="groupId" value="${data.id}"> `
            select += "Год обучения : ";
            for (let i = 1; i < data.eduDuration + 1; i++) {
                if (i == data.course) {
                    select += `<label style="margin-right: 15px"><input class="eduYear" name="eduYear" type="radio" checked value="${i}" /><span>${i}</span></label>`
                } else {
                    select += `<label style="margin-right: 15px"><input class="eduYear" name="eduYear" type="radio" value="${i}" /><span>${i}</span></label>`
                }
            }
            select += "<br />";
            select += "Семестр : ";
            select += `<label style="margin-right: 15px"><input name="semester" class="semester" onclick="changeM(${data.semester})" type="radio" value="${data.semester}" /><span>${data.semester}</span></label>`
            select += `<label style="margin-right: 15px"><input name="semester" class="semester" onclick="changeM(2)" type="radio" value="2" /><span>2</span></label>`
            select += "<br />";
            select += '<div id="sM"></div>';

            $("#Mbody").html(select)
        }, error: () => {
            M.toast({ html: "Произошла ошибка" })
        }
    })

}





$(document).ready(() => {
    $('#exampleModal').on('shown.bs.modal', () => {
        $('#exampleModalLabel').trigger('focus')
    })
    $('#referenceModal').on('shown.bs.modal', () => {
        $('#referenceModalLabel').trigger('focus')
    })
    $('#grMethodsModal').on('shown.bs.modal', () => {
        $('#grMethodsModalLabel').trigger('focus')
    })
    $('#studMethodsModal').on('shown.bs.modal', () => {
        $('#studMethodsModalLabel').trigger('focus')
    })
    $('#CuratorModal').on('shown.bs.modal', () => {
        $('#CuratorModalLabel').trigger('focus')
    })


    
    
})










function changeM(semester) {
    let context = "";
    if (semester == 1) {
        context += "Месяц : ";
        for (let i = 0; i < fSem.length; i++) {
            context += `<label style="margin-right: 15px"><input name="month" class="month" type="radio" value="${fSem[i]}" /><span>${fSem[i]}</span></label>`
        }
        $("#sM").html(context)
    } else if (semester == 2) {
        context += "Месяц : ";
        for (let i = 0; i < sSem.length; i++) {
            context += `<label style="margin-right: 15px"><input name="month" class="month" type="radio" value="${sSem[i]}" /><span>${sSem[i]}</span></label>`
        }
        $("#sM").html(context)
    }
}


function Report() {
    $.ajax({
        url: reportHref,
        beforeSend: () => {
            M.toast({ html: "Генерируется отчет" })
        },
        success: () => {
            $(location).attr("href", reportHref)
        },
        error: () => {
            M.toast({ html: "Ошибка в запросе" })
        }
    })
}


function setSidebar(type) {
    const groups = $("#groups")
    const black = $("#blackList")
    const yellow = $("#yellowList")
    if (type === "group") {
        if (!groups.hasClass("active")) {
            black.removeClass("active")
            yellow.removeClass("active")
            $.ajax({
                url: "/Group/Get",
                method: "Get",
                contentType: "Json",
                success: data => {
                    if (data.key === 200) {

                        sSideB.css("width", "15%")
                        groups.addClass("active")
                        var result = '<table class="table table-hover" >';

                        result += '<thead><tr><th id="gf">Естественно-научный <br/> факультет</th></thead></tr><tbody>'
                        data.data.forEach(el => {
                            if (!el.isfinished) {
                                result += "<tr>"
                                result += `<td  onclick="Modal(${el.id},${$("#hidden").attr("value")})" class="groupsEl"><a href="/Group/desc/${el.id}">${el.name}</a></td>`
                                result += `</tr>`
                            }
                        });
                        data.data.forEach(el => {
                            if (el.isfinished) {
                                result += "<tr>"
                                result += `<td  onclick="Modal(${el.id},${$("#hidden").attr("value")})" class="groupsEl"><a href="/Group/desc/${el.id}">${el.name} (${el.udustart})</a></td>`
                                result += `</tr>`
                            }
                        });
                        result += '</tbody></table>'
                        sSideB.html(`<div id="secondarySideBar1">${result}</div>`)
                    } if (data.key === 404) {
                        M.toast({ html: data.data })
                    }
                }
            }
            )
        } else {
            sSideB.css("width", "0px")
            groups.removeClass("active")
            sSideB.html('')
        }
    } else if (type === "black") {
        if (!black.hasClass("active")) {
            groups.removeClass("active")
            yellow.removeClass("active")
            $.ajax({
                url: "/Skip/blackList",
                method: "Get",
                contentType: "Json",
                success: data => {

                    sSideB.css("width", "15%")
                    black.addClass("active")
                    var result = '<table class="table table-hover" >';

                    result += '<thead><tr><th id="gf">Пропуски 35 и больше</th></thead></tr><tbody>'
                    for (let i = 0; i < data.data.length; i++) {
                        var el = data.idList[i]
                        result += "<tr>"
                        result += `<td   class="blLEl"><a href="/Group/descSorted?id=${el.id}&type=35" >${el.name} <span style="font-size:12px"> (${data.data[i].names.length} учащихся) </span></a></td>`
                        result += `</tr>`
                    }
                    result += '</tbody></table>'
                    sSideB.html(`<div id="secondarySideBar1">${result}</div>`)

                },
                error: () => {
                    M.toast({ html: data.data })
                }
            }
            )



        } else {
            sSideB.css("width", "0px")
            black.removeClass("active")
            sSideB.html('')
        }
    } else if (type === "yellow") {
        if (!yellow.hasClass("active")) {
            black.removeClass("active")
            groups.removeClass("active")
            $.ajax({
                url: "/Skip/yellowList",
                method: "Get",
                contentType: "Json",
                success: data => {

                    sSideB.css("width", "15%")
                    yellow.addClass("active")
                    var result = '<table class="table table-hover" >';

                    result += '<thead><tr><th id="gf">Пропуски 16 и больше</th></thead></tr><tbody>'

                    for (let i = 0; i < data.data.length; i++) {
                        var el = data.idList[i]
                        result += "<tr>"
                        result += `<td   class="yeLEl"><a href="/Group/descSorted?id=${el.id}&type=16" >${el.name} <span style="font-size:12px"> (${data.data[i].names.length} учащихся) </span></a></td>`
                        result += `</tr>`
                    }
                    result += '</tbody></table>'
                    sSideB.html(`<div id="secondarySideBar1">${result}</div>`)

                },
                error: () => {
                    M.toast({ html: data.data })
                }
            })
        } else {
            sSideB.css("width", "0px")
            yellow.removeClass("active")
            sSideB.html('')
        }
    }
}

function GetSemestry() {
    const month = new Date().getMonth();
    if (month >= 9 && month <= 12) {
        return 1;
    } else {
        return 2;
    }
}
