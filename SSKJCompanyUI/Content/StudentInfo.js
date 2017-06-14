$(function () {
    initTable();
});

function initTable() {
    $('.info1').bootstrapTable({
        url: '/Student/GetList',               //请求后台的URL（*）
        method: 'get',                      //请求方式（*）
        toolbar: '#toolbar',                //工具按钮用哪个容器
        striped: true,                      //是否显示行间隔色
        cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        pagination: true,                   //是否显示分页（*）
        sortable: false,                     //是否启用排序
        sortOrder: "asc",                   //排序方式
        queryParams: queryParams,//传递参数（*）
        sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1,                       //初始化加载第一页，默认第一页
        pageSize: 10,                       //每页的记录行数（*）
        pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
        search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
        singleSelect: true,                 // 单选checkbox 
        strictSearch: false,
        showColumns: true,                  //是否显示所有的列
        showRefresh: true,                  //是否显示刷新按钮
        clickToSelect: true,                //是否启用点击选中行
        height:100,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
        uniqueId: "ClassId",                     //每一行的唯一标识，一般为主键列
        columns: [
        {
            checkbox: true
        },
        {
            field: 'StudentId',
            title: '学生ID',
            align: 'center',
            valign: 'middle',
            sortable: true
        }, {
            field: 'Name',
            title: '学生姓名',
            align: 'center',
            valign: 'middle',
            sortable: true
        }, {
            field: 'XH',
            title: '学号',
            align: 'center',
            valign: 'middle'
        },
        {
           field: 'ClassId',
           title: '班级ID',
           align: 'center',
           valign: 'middle',
           sortable: true
        },
        {
            field: 'Sex',
            title: '性别',
            align: 'center',
            valign: 'middle',
            sortable: true
        }, ],
        onClickRow: function (item, td) {
            document.getElementById("_id").value = item.ClassId;
            document.getElementById("_name").value = item.ClassName;
            document.getElementById("_number").value = item.PersonNumber;
        },
    });
}

function queryParams(params) {
    var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
        limit: params.limit,   //页面大小
        offset: params.offset,  //页码
        //id: document.getElementById("treeId").value,
    };
    return temp;
};
function add() {
    $("#Modal_add").modal().on("shown.bs.modal");
}
function edit() {
    document.getElementById("edit_name").value = document.getElementById("_name").value;
    document.getElementById("edit_XH").value = document.getElementById("_XH").value;
    document.getElementById("edit_classId").value = document.getElementById("_classId").value;
    document.getElementById("edit_sex").value = document.getElementById("_sex").value;

    var id = $("#_id").val();
    if (id == "" || id == null) {
        alert("请选择一条要修改的数据！")
    } else {
        $("#Modal_edit").modal().on("shown.bs.modal");
    }
}