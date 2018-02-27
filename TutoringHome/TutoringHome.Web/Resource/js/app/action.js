
define(["jquery", "app/render", "app/model", "app/common", "jquery-ui", "validate", "validate-ubo", "ubo-ajax"], function ($, render, model, common) {
    var action =
        {
            btnSubmit: function ()
            {
                if ($('.form-horizontal').valid())
                {
                    $('.form-horizontal').attr("action", "http://tutoringhome.163vps.cn/TutorCandidates/Save").submit();
                }
            }
        }
    return action;
})