const tblBlog = "Tbl_Blog";

run();

function run() {
    getItem();
    // createItem('title2','author','string content');
    // Edit();
    // deleteItem();
    // updateItem('title123','author123','string content 123');

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
    let result = confirm('Are you sure you want to delete?');
    if(!result) return;
    let blogArr = getBlogs();

    var lst = blogArr.filter(x => x.Id != id);

    lst = JSON.stringify(lst);
    localStorage.setItem(tblBlog, lst);
    getItem();
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

$('#save').click(function () {
    const title = $("#Title").val();
    const author = $("#Author").val();
    const content = $("#Content").val();

    if(_blogId === '') {
        createItem(title, author, content);

    alert('save successfully');

    } else {
        updateItem(_blogId,title,author,content);
        alert('update successfully');
    }
    $("#Title").val('');
    $("#Author").val('');
    $("#Content").val('');

    $("#Title").focus();

    getItem();

});

$('#edit').click(function() {

});

$('#delete').click(function() {

});