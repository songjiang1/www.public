/*
*
* 版权所有，使用请尊重作者知识产权，QQ：15052909
*
* */

/*字体rem动态设置*/
(function (doc, win, page_width, font_size) {
    var docEl = doc.documentElement,
        resizeEvt = 'orientationchange' in window ? 'orientationchange' : 'resize',
        recalc = function () {
            var clientWidth = docEl.clientWidth;
            if (!clientWidth) return;
            docEl.style.fontSize = clientWidth > page_width ? (font_size * 2) + 'px' : font_size * (clientWidth / (page_width / 2)) + 'px';
        };
    if (!doc.addEventListener) return;
    win.addEventListener(resizeEvt, function () {
        recalc();
    }, false);
    doc.addEventListener('DOMContentLoaded', function () {
        recalc();
    }, false);
})(document, window, 750, 50); // 设计图宽度，字体大小

function selectSwiper(obj) {
    var _self = this;
    _self.el = $(obj.el); // 根元素
    _self.selectSwiper = null; // swiper对象
    _self.swiperData = {}; // swiper数据对象
    _self.swiperData.mustSelect = obj.mustSelect || false; // 是否必选
    _self.swiperData.activeIndex = (typeof obj.activeIndex === 'number' && obj.activeIndex >= -1) ? obj.activeIndex : -1;// 激活索引
    _self.swiperData.oldIndex = _self.swiperData.activeIndex; // 旧索引，取消返回上一次索引
    _self.swiperData.data = obj.data || []; // swiper数据

    _self.swiperData.okFun = obj.okFun; // OK按钮执行函数
    _self.swiperData.okFunUndefind = obj.okFunUndefind || function () {
    };//选择说明项-'请选择'
    _self.swiperData.closeFun = obj.closeFun || function () {
    }; // 取消按钮执行函数
    _self.swiperData.init = obj.init; // 初始化
    var hgSelect = `
        <div class="select">
            <span class="close">取消</span>
            <span class="ok">确定</span>
            <div class="selectData">
                <div class="swiper-container">
                    <div class="cloth"></div>
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">请选择</div>
                    </div>
                </div>
            </div>
        </div>
    `;
    _self.init = function () { // 初始化
        _self.el.html(hgSelect);
        _self.el.addClass('click_no'); // 取消移动端点击阴影
        _self.selectSwiper = new Swiper(obj.el + ' .swiper-container', {
            direction: 'vertical',
            slidesPerView: 4,//可视区域数目
            centeredSlides: true,//激活项居中
            slideToClickedSlide: true,//点击切换
            onInit: function (swiper) {
                swiper.removeSlide(0);
                var data = _self.swiperData.data;
                var s = [];
                s[0] = '<div class="swiper-slide">请选择</div>';
                for (i = 0; i < data.length; i++) {
                    s[i + 1] = '<div class="swiper-slide" data-value="' + data[i].split(',')[0] + '">' + data[i].split(',')[1] + '</div>';
                }
                swiper.appendSlide(s);
                _self.swiperData.init(_self.swiperData.activeIndex);

            },
            onSlideChangeEnd: function (swiper) {
                _self.swiperData.activeIndex = swiper.activeIndex - 1;
            },
        });
        _self.el.find('.ok').on('click', _self.okSelectSwiper);
        _self.el.find('.close').on('click', function () {
            _self.swiperData.activeIndex = _self.swiperData.oldIndex;
            _self.swiperData.closeFun();
            _self.closeSelectSwiper();
        });
        _self.el.on('click', function () {
            _self.el.find('.close').trigger('click');
        });
        $('.select').on('click', function (e) {//阻止选择区域关闭select
            e.stopPropagation();
        });
    };
    _self.openSelectSwiper = function () {
        var _self = this;
        _self.el.addClass('yes');
        _self.selectSwiper.update();
        _self.selectSwiper.slideTo(_self.swiperData.activeIndex + 1, 0);
    };
    _self.okSelectSwiper = function () {
        if (_self.swiperData.mustSelect && _self.swiperData.activeIndex === -1) {
            _self.swiperData.okFunUndefind();
        } else {
            _self.swiperData.okFun(_self.swiperData.activeIndex);
            _self.swiperData.oldIndex = _self.swiperData.activeIndex;
            _self.closeSelectSwiper();
        }
    };
    _self.closeSelectSwiper = function () {
        _self.el.removeClass('yes');
    };
    _self.init();
}

