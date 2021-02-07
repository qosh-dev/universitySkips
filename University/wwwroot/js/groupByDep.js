$(document).ready(() => {
    var month = $("#month");

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
    
    var optionsF = '<select name="month" >';
    
    var optionsS = '<select name="month" >';
    
    fSem.forEach(month => {
        optionsF += '<option value=' + month + '>' + month + '</option>'
    });
    
    optionsF += '</select>'
    
    sSem.forEach(month => {
        optionsS += '<option value=' + month + '>' + month + '</option>'
    });
    
    optionsS += '</select>'

    month.html("Выберите месяц  : " + optionsF)

    $("#r1").on("click",() => {
        month.html("Выберите месяц  : " + optionsF)
    })
    
    $("#r2").on("click",() => {
        month.html("Выберите месяц  : " + optionsS)
    })






})