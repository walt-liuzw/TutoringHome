
define(function () {

    var common = {
        urlGet: function () { //取得Get参数

            var aQuery = window.location.href.split("?");
            var aGET = {};
            if (aQuery.length > 1) {
                var aBuf = aQuery[1].split("&");
                for (var i = 0, iLoop = aBuf.length; i < iLoop; i++) {
                    var aTmp = aBuf[i].split("=");  //分离key与Value
                    aGET[aTmp[0]] = aTmp[1];
                }
            }
            return aGET;
        },
        ajax: function (url, data, successfn, errorfn) {
            data = (data == null || data == "" || typeof (data) == "undefined") ? { "date": new Date().getTime() } : data;
            var xhr = $.ajax({
                type: "post",
                data: data,
                url: url,
                dataType: "json",
                success: function (d) {
                    if (d != 'No Access Available' && d != 'Error') {
                        successfn(d);
                    }
                    else {
                        alert('Ajax Error');
                    }

                },
                error: function (e) {
                    alert('Ajax Error');
                }
            });

            setTimeout(function () {
                if (xhr.readyState !== 4) {
                    xhr.abort();
                    alert('Ajax Abort');
                }
            }, 8000);
        },
        ajax_tool: function (url, data, successfn, errorfn) {
            data = (data == null || data == "" || typeof (data) == "undefined") ? { "date": new Date().getTime() } : data;
            var xhr = $.ajax({
                type: "post",
                data: data,
                url: url,
                dataType: "",
                success: function (d) {
                    if (d != 'No Access Available' && d != 'Error') {
                        successfn(d);
                    }
                    else {
                        alert('Ajax Error');
                    }

                },
                error: function (e) {
                    alert('Ajax Error');
                }
            });

            setTimeout(function () {
                if (xhr.readyState !== 4) {
                    xhr.abort();
                    alert('Ajax Abort');
                }
            }, 30000);
        },
        getRootPath: function (argument) {
            var curWwwPath = window.document.location.href;
            var pathName = window.document.location.pathname;
            var pos = curWwwPath.indexOf(pathName);
            var localhostPaht = curWwwPath.substring(0, pos);
            var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);
            var rootPath = localhostPaht + projectName;
            return rootPath;
        },
        toQueryString: function (obj) {
            var ret = [];
            for (var key in obj) {
                key = encodeURIComponent(key);
                var values = obj[key];
                if (values && values.constructor == Array) {//数组 
                    var queryValues = [];
                    for (var i = 0, len = values.length, value; i < len; i++) {
                        value = values[i];
                        queryValues.push(this.toQueryPair(key, value));
                    }
                    ret = ret.concat(queryValues);
                } else { //字符串 
                    ret.push(this.toQueryPair(key, values));
                }
            }
            return ret.join('&');
        },
        toQueryPair: function (key, value) {
            if (typeof value == 'undefined') {
                return key;
            }
            return key + '=' + encodeURIComponent(value === null ? '' : String(value));
        }

    }
    return common;
})