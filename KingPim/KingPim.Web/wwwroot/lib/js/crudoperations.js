$(document).ready(function () {
    // CREATE:
    $('#createSomething').click(function () {
        $('#createModal').on('show.bs.modal', function () {
            var modal = $(this);
            modal.find('.modal-body select');

            $('#addSubCatForm').submit(function (e) {
                e.preventDefault;

                var formData = new FormData();
                var inputValue = $('#addSubCatForm input').val();
                formData.append('name', inputValue);

                var catSelectValue = $('#catSelect').val();
                formData.append('categoryId', catSelectValue);

                // var attGrSelectValue = $('#attGrSelect').val();
                $('#attGrSelect').each(function () {
                    formData.append('AttributeGroupId', $(this).val());
                });

                $.ajax({
                    type: 'POST',
                    url: '/SubCategory/Add',
                    data: formData,
                    dataType: 'JSON',
                    success: function () {
                        console.log("WIHUUUUUU!");
                        window.location.href() = data;
                    },
                    error: function () {
                        console.log("DOOOOOOEEEHHHHH!");
                    }
                });
            });
        });
    });

    // UPDATE:
    $('#updateSomething').click(function () {      
        
        $('#updateModal').on('show.bs.modal', function () {
            var modal = $(this);
            var name = $(".table").find("input:checked").attr("data-name");
            modal.find('.modal-body p strong').text('You are about to update "' + name + '"');
        });
    });

    //Update AttributeGroup
    $('#editAttrGroupModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var textareaRecipient = button.data('textarea');
        var modal = $(this);
        modal.find('.modal-body input').val(nameRecipient);
        modal.find('.modal-body textarea').val(textareaRecipient);

        $('#editAttrGroupForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();
            formData.append('id', idRecipient);
            $('#editAttrGroupForm input').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            var testTextarea = $('#editAttrGroupForm textarea').val();
            formData.append('description', testTextarea);
            $.ajax({
                url: '/AttributeGroupViewModel/Update',
                type: 'POST',
                data: formData,
                dataType: 'json',
                processData: false,
                contentType: false,
                success: function (data) {
                    console.log(data);
                    window.location.href = data;
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });

    // DELETE: AttributeGroup
    $('#deleteAttrGroupModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete Attribute group ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });

    // Delete Attribute
    $('#deleteProductAttrModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete product Attribute ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });

    // Edit Category
    $('#editModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-body input').val(nameRecipient);
        $('#editCatForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();
            formData.append('id', idRecipient);
            $('#editCatForm input').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            $.ajax({
                url: '/Category/Update',
                type: 'POST',
                data: formData,
                dataType: 'json',
                processData: false,
                contentType: false,
                success: function (data) {
                    console.log(data);
                    window.location.href = data;
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
        console.log(idRecipient);
    });
    // Delete Category.
    $('#deleteProductModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idCategory = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete category ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idCategory);
        console.log(idCategory);
    });

    // edit subcategory
    // delete subgategory
    $('#deleteModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });

    //update product
    $('#editProductModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var priceRecipient = button.data('price');
        var textareaRecipient = button.data('textarea');
        var modal = $(this);
        modal.find('#inputId').val(idRecipient);
        modal.find('#inputName').val(nameRecipient);
        modal.find('#inputPrice').val(priceRecipient);
        modal.find('.modal-body textarea').val(textareaRecipient);
    });

    //delete product
    $('#deleteProductModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
    });
});