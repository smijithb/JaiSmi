Namespace("sj.blog", {
    ckeditorBasicConfig : {
        toolbar: [
           ['Styles', 'Format', 'Font', 'FontSize'],
           '/',
           ['Bold', 'Italic', 'Underline', 'StrikeThrough', '-', 'Undo', 'Redo', '-', 'Cut', 'Copy', 'Paste', 'Find', 'Replace', '-', 'Outdent', 'Indent', '-']
        ]
    },
    onEditBlogPost: function () {
        var postTitleElem = $('#divPostTitle');

        if (postTitleElem.html() == '') {
            postTitleElem.html('A new blog post');
        }

        if (typeof CKEDITOR.instances.divPostTitle === typeof undefined) {
            $('#divPostTitle').attr('contenteditable', true);
            CKEDITOR.inline('divPostTitle', sj.blog.ckeditorBasicConfig);
            CKEDITOR.replace('divPostContent');
            $('.post-btns-container').toggleClass('nodisplay ');
        }

        $('#btnSavePost').on('click', function () {
            $(this).attr('disabled', true);
            var postTitleEditor = CKEDITOR.instances.divPostTitle;
            var postContentEditor = CKEDITOR.instances.divPostContent;
            var postTitle = postTitleEditor.getData();
            var postContent = postContentEditor.getData();
            postTitleEditor.updateElement();
            postContentEditor.updateElement();

            if ($.trim(postTitle) != '' && $.trim(postContent) != '') {
                $.ajax({
                    url: '/blog/post/update',
                    method: "POST",
                    data: { postId: parseInt($('.blog-post-container').attr('data-blog-id')), postTitle: encodeURIComponent(postTitle), postContent: encodeURIComponent(postContent) }
                }).done(function (_result) {
                    if (_result) {
                        var resultDetails = JSON.parse(JSON.stringify(_result));

                        if (resultDetails.IsSuccess) {
                            postTitleEditor.destroy(true);
                            postContentEditor.destroy(true);
                            $('#divPostTitle').attr('contenteditable', false);
                            $('.post-btns-container').toggleClass('nodisplay ');

                            if (resultDetails.UrlToRedirect != null && resultDetails.UrlToRedirect != '') {
                                document.location.href = resultDetails.UrlToRedirect;
                            }
                        }
                    }
                });
            }

            $('#btnSavePost').off('click');
            $(this).attr('disabled', false);
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
        sj.blog.onEditBlogPost();
        return false;
    });
});