async function removeCategoryDelete(){
    if(document.querySelector("#selectCategory").value == null 
        || +document.querySelector("#selectCategory").value < 1)
        return;

    const token = localStorage.getItem("JWT_Access");
    const categoryId = +document.querySelector("#selectCategory").value;
    //alert(categoryId);
    const url = `https://localhost:44315/admin/categories/${categoryId}`;
    const response = await fetch(url, {
        method: "DELETE",
        headers: { 
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token 
        },
        body: JSON.stringify({
            categoryId: categoryId
        })
    });
    if (response.status == 204) {
        await createDropDownCategories();
        //alert("success");
        router.loadRoute('');
    }
    else if (response.status == 401){
        let result = await refresh();
        if(result == 200)
            await removeCategoryDelete();
    }
    else if (response.status == 405){
        await logout();
    }
    else if (response.status == 404) {
        document.querySelector("#error").innerHTML = createLoginError("Not fount category").toString();
    }
}