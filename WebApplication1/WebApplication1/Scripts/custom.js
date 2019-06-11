
//$(".form1delete").hover(function () {
//    $(".form1input1").attr("placeholder","輸入ID即可刪除該筆資料");
//}, function () {
//    $(".form1input1").attr("placeholder", "");
//    }
//);

$("tr.dataTr").hover(function () {
    $(this).css("background-color", "#414141");
}, function () {
    $(this).css("background-color", "#333");
}
);

$("button[value=21]").on("click", function () {
    var $this = $(this);
    var td1_id = $this.parents().siblings("td:first-child");
    var td2_name = $this.parents().siblings("td:nth-child(2)");
    var td3_age = $this.parents().siblings("td:nth-child(3)");
    var tdl_butt = $this.parents("td:last-child");
    var thisId = td1_id.text();
    var thisName = td2_name.text();
    var thisAge = td3_age.text();
    $("button[value=21]").hide();
    $("button.form2delete").hide();
    td1_id.append("<input type='hidden' class='form-control' name='ID' value='" + thisId + "'>");
    td2_name.append("<input type='text' class='form-control' name='NAME' value='" + thisName + "'>");
    td3_age.append("<input type='text' class='form-control' name='AGE' value='" + thisAge + "'>");
    $("td:nth-child(2) input").select();
    tdl_butt.prepend("<button class='btn btn-warning' type='submit' name='update' value='updatemono' onclick='submitForm2()'>確定</button>");
    tdl_butt.append("<button class='btn btn-secondary' type='submit' name='cancel' value='23' onclick='removeInput()'>取消</button>");
});

function submitForm2() {
    $(".formList").submit();
}

function removeInput() {
    $("table input").remove();
    $("button[value='updatemono']").remove();
    $("button[value=23]").remove();
    $("button[value=21]").show();
    $("button.form2delete").show();
};

$("button.form2delete").on("click", function () {
    var td1_id = $(this).parents().siblings("td:first-child");
    var thisId = td1_id.children("p").text();
    ////thisButt.addClass("deleteClicked");
    td1_id.append("<input type='hidden' name='ID_Del' value='" + thisId + "'>");
    if (confirm("確定刪除此筆資料?") == true) {
        submitForm2();
    } else {
        $("input[type='hidden']").remove();
    }
});   

