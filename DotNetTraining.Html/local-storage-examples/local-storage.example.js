const tblBlog = "Tbl_Blog";

run();

function run() {
    // getItem();
    // createItem('title2','author','string content');
    // Edit();
    // deleteItem();
    updateItem('title123','author123','string content 123');

}

function getItem() {
    let blogArr = getBlogs();

    for (let i = 0; i < blogArr.length; i++) {
        let blog = blogArr[i];
        console.log(blog.Title);
    }
}

function Edit() {
    let blogArr = getBlogs();

    var id = prompt("Please enter your id");

    var lst = blogArr.filter(x => x.Id == id);
    
    if(lst.length != 0) {
        console.log(lst[0].Author);
        console.log(lst[0].Content);
        console.log(lst[0].Title);
    } else {
        console.log('No Data Found');
        return;
    }
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

function updateItem(title, author, content) {
    let blogArr = getBlogs();

    var id = prompt("Please enter your id");

    var lst = blogArr.filter(x => x.Id == id);
    if(lst.length === 0) {
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

function deleteItem() {
    let blogArr = getBlogs();

    var id = prompt("Please enter your id");

    var lst = blogArr.filter(x => x.Id != id);

    lst = JSON.stringify(lst);
    localStorage.setItem(tblBlog,lst);

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