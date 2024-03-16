const tblBlog = "Tbl_Blog";
var _blogId = "";
run();

function run() {
    getItem();
    // createItem('title2','author','string content');
    // Edit();
    // deleteItem();
    // updateItem('title123','author123','string content 123');
    // for(let i = 0; i <= 100; i++) {

    //     setTimeout(() => {
    //         createItem('title' + i + 1,'author' + i + 1,'string content' + i + 1);
    //     }, 100);
    // }
}

function getItem() {
    $('#tBody').html('');

    let blogArr = getBlogs();

    let htmlRow = '';

    for (let i = 0; i < blogArr.length; i++) {
        const item = blogArr[i];

        htmlRow += `
        <tr>
            <td>
            <button type="button" class="btn btn-warning" onClick="edit('${item.Id}')">Edit</button>
            <button type="button" class="btn btn-danger" onClick="deleteItem('${item.Id}')">Delete</button>
            </td>
            <th scope="row">${i + 1}</th>
            <td>${item.Title}</td>
            <td>${item.Author}</td>
            <td>${item.Content}</td>
        </tr>
       `
    }
    $('#tBody').html(htmlRow);
}

function edit(id) {
    let blogArr = getBlogs();

    console.log(id);
    var lst = blogArr.filter(x => x.Id == id);

    if (lst.length === 0) {
        console.log('No Data Found');
        return;
    }
    let item = lst[0];

    $("#Title").val(item.Title);
    $("#Author").val(item.Author);
    $("#Content").val(item.Content);
    _blogId = item.Id;
}

function createItem(title, author, content) {
    let blogArr = getBlogs();

    const blog = {
        Id: uuidv4(),
        Title: title,
        Author: author,
        Content: content
    };

    blogArr.push(blog);

    jsonblog = JSON.stringify(blogArr);

    localStorage.setItem(tblBlog, jsonblog);

    getItem();
}

function updateItem(id, title, author, content) {
    let blogArr = getBlogs();

    var lst = blogArr.filter(x => x.Id == id);
    if (lst.length === 0) {
        console.log("No Data Found");
        return;
    }

    let index = blogArr.findIndex(x => x.Id === id);
    blogArr[index] = {
        Id: id,
        Title: title,
        Author: author,
        Content: content
    };

    jsonblog = JSON.stringify(blogArr);

    localStorage.setItem(tblBlog, jsonblog);

}

function deleteItem(id) {
    // Swal.fire({
    //     title: "Are you sure, you want to delete?",
    //     text: "You won't be able to revert this!",
    //     icon: "question",
    //     showCancelButton: true,
    //     confirmButtonColor: "#3085d6",
    //     cancelButtonColor: "#d33",
    //     confirmButtonText: "Yes"
    // }).then((result) => {
    //     if (result.isConfirmed) {
    //         let blogArr = getBlogs();

    //         var lst = blogArr.filter(x => x.Id != id);

    //         lst = JSON.stringify(lst);
    //         localStorage.setItem(tblBlog, lst);
    //         saveSuccess('Delete Success');
    //         getItem();
    //     }
    // });

    Notiflix.Confirm.show(
        'Are you sure, you want to delete?',
        "You won't be able to revert this!",
        'Yes',
        'No',
        function okCb() {
            let blogArr = getBlogs();

            var lst = blogArr.filter(x => x.Id != id);

            lst = JSON.stringify(lst);
            localStorage.setItem(tblBlog, lst);
            saveSuccess('Delete Success');
            getItem();
        },
    );

    // let result = confirm('Are you sure you want to delete?');
    // if(!result) return;
    // let blogArr = getBlogs();

    // var lst = blogArr.filter(x => x.Id != id);

    // lst = JSON.stringify(lst);
    // localStorage.setItem(tblBlog, lst);
    // getItem();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

function getBlogs() {
    let blogArr = [];
    let blogString = localStorage.getItem(tblBlog);

    if (blogString != null) {
        blogArr = JSON.parse(blogString);
    }

    return blogArr;
}

$('#save').click(function (e) {
    e.preventDefault();

    var l = Ladda.create(this);
	l.start();

    const title = $("#Title").val();
    const author = $("#Author").val();
    const content = $("#Content").val();

    if (_blogId === "") {
        setTimeout(() => {
            createItem(title, author, content);
            saveSuccess('Save Success');
        },3000);
        $("#Title").val('');
        $("#Author").val('');
        $("#Content").val('');
    
        $("#Title").focus();
    
        getItem();
        l.stop();

    } else {
        updateItem(_blogId, title, author, content);
        saveSuccess('Update Success');
        $("#Title").val('');
        $("#Author").val('');
        $("#Content").val('');
    
        $("#Title").focus();
    
        getItem();
        l.stop();
    }

});

function saveSuccess(message) {
    // Swal.fire({
    //     text: message,
    //     icon: "success"
    // });
    Notiflix.Notify.success(message);
}