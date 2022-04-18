async function categoryPost(category){
    const token = localStorage.getItem("JWT_Access");
    const response = await fetch("https://localhost:44315/admin/categories/create", {
        method: "POST",
        headers: 
        { 
            "Content-Type": "application/json" ,
            "Authorization": "Bearer " + token 
        },
        body: JSON.stringify(category)
    });
    if (response.status == 204) {
        await createDropDownCategories();
        //alert("success");
        router.loadRoute('');
    }
    else if (response.status == 401){
        let result = await refresh();
        if(result == 200)
            await categoryPost(category);
    }
    else if (response.status == 405){
        await logout();
    }
    else if(response.status == 400){
        const data = await response.json();
        createLoginError(data.error);
        document.querySelector("#error").innerHTML = createLoginError(data.error).toString();
    }
    else{
        alert("error")
    }
}

async function createCategory(){
    if(document.querySelector("#formWhite").value == null 
        || +document.querySelector("#formWhite").value.length < 2)
        return;

    const nameCategory = document.querySelector("#formWhite").value;
    document.querySelector("#formWhite").value = "";
    const newCategory= {
        name: nameCategory,
    };
    await categoryPost(newCategory);
}
