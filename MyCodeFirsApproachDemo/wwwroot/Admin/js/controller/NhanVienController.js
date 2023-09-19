var staff = {
    init: function () {
        staff.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/NhanVien/ChangeStatus",
                data: { id: id },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Nam');
                        btn.removeClass('btn-primary').addClass('btn-warning');
                    }
                    else {
                        btn.text('Nữ');
                        btn.removeClass('btn-warning').addClass('btn-primary');

                    }
                }
            });
        });


        $("#SearchString").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/NhanVien/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            focus: function (event, ui) {
                $("#SearchString").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#SearchString").val(ui.item.label);
                return false;
            }
        });




        $(function () {
            $('#AlertBox').removeClass('hide');
            $('#AlertBox').delay(5000).slideUp(500);
        });

        $('#CityId').on('change', function (event) {
            var form = $(event.target).parents('form');
            form.submit();
        });
    }
}
staff.init();