$(function () {

    if (localStorage.chkbx && localStorage.chkbx != '') {
        $('#remember_me').attr('checked', 'checked');
        $('#Email').val(localStorage.usrname);
        $('#Password').val(localStorage.pass);
    } else {
        $('#remember_me').removeAttr('checked');
        $('#Email').val('');
        $('#Password').val('');
    }

    $('#remember_me').click(function () {

        if ($('#remember_me').is(':checked')) {
            // save username and password
            localStorage.usrname = $('#Email').val();
            localStorage.pass = $('#Password').val();
            localStorage.chkbx = $('#remember_me').val();
        } else {
            localStorage.usrname = '';
            localStorage.pass = '';
            localStorage.chkbx = '';
        }
    });
});