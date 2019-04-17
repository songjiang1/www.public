$(function () {

    var hgS1 = new selectSwiper({
        el:'.select_box1',
        // mustSelect:true, // 是否必选，默认false
        // activeIndex: 0,//默认激活项下标，默认值：-1
        data: ['吃饭', '睡觉', '打豆豆'],//选项数据
        init:function(index){
            if(index !== -1){
                $('.btn1').html(this.data[index]);
            }
        },
        okFunUndefind: function () {//选择说明项-'请选择'
            alert('必须选择一项');
            return false;
        },
        okFun: function (index) {//确认按钮
            console.log(index);
            $('.btn1').html(this.data[index]);
        },
        closeFun: function () {//取消按钮
            console.log('取消');
        },
    });
    $('.btn1').on('click', function () {
        hgS1.openSelectSwiper(); // 打开选择框
    });


    var hgS2 = new selectSwiper({
        el:'.select_box2',
        mustSelect:true, // 是否必选，默认false
        activeIndex: 0,//默认激活项下标，默认值：-1
        data: ['哈哈2', '呵呵2', '嘻嘻2', '嘿嘿2', '呼呼2', '咳咳2', '嘘嘘2'],//选项数据
        init:function(index){
            if(index !== -1){
                $('.btn2').html(this.data[index]);
            }
        },
        okFunUndefind: function () {//选择说明项-'请选择'，mustSelect为true生效
            alert('必须选择一项');
            // return false;
        },
        okFun: function (index) {//确认按钮
            $('.btn2').html(this.data[index]);
        },
        closeFun: function () {//取消按钮
            console.log('取消');
        },
    });
    $('.btn2').on('click', function () {
        hgS2.openSelectSwiper(); // 打开选择框
    });


    var hgS3 = new selectSwiper({
        el:'.select_box3',
        mustSelect:true, // 是否必选，默认false
        activeIndex: 5,//默认激活项下标
        data: ['星期一','星期二','星期三','星期四','星期五','星期六','星期日'],//选项数据
        init:function(index){
            if(index !== -1){
                $('.btn3').val(this.data[index]);
            }
        },
        okFunUndefind: function () {//选择说明项-'请选择'
            alert('必须选择一项');
            return false;
        },
        okFun: function (index) {//确认按钮
            $('.btn3').val(this.data[index]);
        },
        closeFun: function () {//取消按钮
            console.log('取消');
        },
    });
    $('.btn3').on('click', function () {
        hgS3.openSelectSwiper(); // 打开选择框
    });
});
