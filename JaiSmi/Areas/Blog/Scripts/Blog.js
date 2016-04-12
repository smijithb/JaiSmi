Namespace("sj.blog", {
    ckeditorBasicConfig : {
        toolbar: [
           ['Styles', 'Format', 'Font', 'FontSize'],
           '/',
           ['Bold', 'Italic', 'Underline', 'StrikeThrough', '-', 'Undo', 'Redo', '-', 'Cut', 'Copy', 'Paste', 'Find', 'Replace', '-', 'Outdent', 'Indent', '-']
        ]
    },
    editBlogPost: function () {
        if (typeof CKEDITOR.instances.divPostTitle === typeof undefined) {
            $('#divPostTitle').attr('contenteditable', true);
            CKEDITOR.inline('divPostTitle', sj.blog.ckeditorBasicConfig);
            CKEDITOR.replace('divPostContent');
            $('.post-btns-container').toggleClass('nodisplay ');
        }

        $('#btnSavePost').on('click', function () {
            var postTitleEditor = CKEDITOR.instances.divPostTitle;
            var postContentEditor = CKEDITOR.instances.divPostContent;
            var postTitle = postTitleEditor.getData();
            var postContent = postContentEditor.getData();
            postTitleEditor.updateElement();
            postContentEditor.updateElement();

            $.ajax({
                url: '/blog/post/update',
                method: "POST",
                data: { postId: parseInt($('.blog-post-container').attr('data-blog-id')), postTitle: encodeURIComponent(postTitle), postContent: encodeURIComponent(postContent) }
            }).done(function (_isSuccess) {
                if (_isSuccess) {
                    postTitleEditor.destroy(true);
                    postContentEditor.destroy(true);
                    $('#divPostTitle').attr('contenteditable', false);
                    $('.post-btns-container').toggleClass('nodisplay ');
                }
            });
        });

        $('#btnCancelPost').on('click', function () {
            var postTitleEditor = CKEDITOR.instances.divPostTitle;
            var postContentEditor = CKEDITOR.instances.divPostContent;
            postTitleEditor.destroy(true);
            postContentEditor.destroy(true);
            $('#divPostTitle').attr('contenteditable', false);
            $('.post-btns-container').toggleClass('nodisplay ');
        });
    }
});

$(document).ready(function () {
    $('.edit-icon').on('click', function () {
        sj.blog.editBlogPost();
        return false;
    });
});