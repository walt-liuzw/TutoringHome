﻿require.config({
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
require(["app/action", "underscore", "backbone", "jquery", "jquery-ui", "bootstrap", "validate", "validate-ubo"], function (action, underscore, Backbone) {
    var AppView = Backbone.View.extend({
        el: $('body'),
        initialize: function () {
        },
        events: {
            'click #btnSubmit': action.btnSubmit
        }

    });
    var app = new AppView();

    return app;
})