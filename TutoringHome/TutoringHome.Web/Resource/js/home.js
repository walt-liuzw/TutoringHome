require.config({
    baseUrl: 'http://tutoringhome.163vps.cn/Resource/js/lib',
    paths: {
        app: "../app",
        main: "../../js",
        "jquery": "jquery",
        "bootstrap": "bootstrap.min",
        "ubo-ajax": "jquery.unobtrusive-ajax.min",
        "validate": "jquery.validate.min",
        "validate-ubo": "jquery.validate.unobtrusive.min"
    },
    shim: {
        "ubo-ajax": ["jquery"],
        "validate": ["jquery"],
        "bootstrap": ["jquery"],
        "validate-ubo": ["jquery", "validate"]
    }
})
require(["http://tutoringhome.163vps.cn/Resource/js/app/action.js?ts=" + new Date().getTime(), "underscore", "backbone", "jquery", "jquery-ui", "bootstrap", "validate", "validate-ubo"], function (action, underscore, Backbone) {
    var AppView = Backbone.View.extend({
        el: $('body'),
        events: {
            'click #btnSubmit': action.btnSubmit,
            'click #addSubject': action.addSubject
        }

    });
    var app = new AppView();

    return app;
})
