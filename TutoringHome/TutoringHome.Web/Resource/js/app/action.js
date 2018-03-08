
define(["jquery", "app/render", "app/model", "app/common", "jquery-ui", "validate", "validate-ubo", "ubo-ajax"], function ($, render, model, common) {
    var action =
        {
            btnSubmit: function ()
            {
                if ($('.form-horizontal').valid())
                {
                    //校验年龄
                    var regNum = /^[0-9]{1,2}$/;
                    if (!regNum.test($('#txt_age').val()))
                    {
                        alert("请输入正确的年龄！")
                        return;
                    }
                    //校验手机
                    var regMobile = /^[1][3,4,5,7,8][0-9]{9}$/;;
                    if (!regMobile.test($('#txt_mobile').val())) {
                        alert("请输入有效的手机号！")
                        return;
                    }
                    $('.form-horizontal').attr("action", "http://tutoringhome.163vps.cn/TutorCandidates/Save").submit();
                }
            },
            btnEdit: function ()
            {
                $("#txt_name").removeAttr("readonly");
                $('#radio_Male').attr("disabled", false);
                $('#radio_Female').attr("disabled", false);
                $("#txt_age").removeAttr("readonly");
                $("#txt_graduate").removeAttr("readonly");
                $("#txt_major").removeAttr("readonly");
                $("#txt_subject").removeAttr("readonly");
                $('#radio_all').attr("disabled", false);
                $('#radio_weekend').attr("disabled", false);
                $('#radio_workday').attr("disabled", false);
                $("#txt_experience").removeAttr("readonly");
                $("#txt_evaluation").removeAttr("readonly");
                $("#txt_domicile").removeAttr("readonly");
                $("#txt_mobile").removeAttr("readonly");
                $("#btnEditSubmit").css("display","block");
            },
            btnEditSubmit: function ()
            {
                if (action.checkData()) {
                    //校验年龄
                    var regNum = /^[0-9]{1,2}$/;
                    if (!regNum.test($('#txt_age').val())) {
                        alert("请输入正确的年龄！")
                        return;
                    }
                    //校验手机
                    var regMobile = /^[1][3,4,5,7,8][0-9]{9}$/;;
                    if (!regMobile.test($('#txt_mobile').val())) {
                        alert("请输入有效的手机号！")
                        return;
                    }

                    var teacherinfoid = $("#teacherinfoid").val();
                    $('.form-horizontal').attr("action", "http://tutoringhome.163vps.cn/TutorCandidates/Update?id=" + teacherinfoid).submit();
                }
            },
            checkData: function ()
            {
                if ($("#txt_name").val() == "")
                {
                    alert("姓名不能为空！");
                    return false;
                }
                if ($("#txt_age").val() == "") {
                    alert("年龄不能为空！");
                    return false;
                }
                if ($("#txt_graduate").val() == "") {
                    alert("毕业院校不能为空！");
                    return false;
                }
                if ($("#txt_major").val() == "") {
                    alert("专业不能为空！");
                    return false;
                }
                if ($("#txt_subject").val() == "") {
                    alert("擅长年级与科目不能为空！");
                    return false;
                }
                if ($("#txt_experience").val() == "") {
                    alert("教育经验不能为空！");
                    return false;
                }
                if ($("#txt_domicile").val() == "") {
                    alert("现居住地不能为空！");
                    return false;
                }
                if ($("#txt_mobile").val() == "") {
                    alert("联系电话不能为空！");
                    return false;
                }
                return true;
            }
        }
    return action;
})