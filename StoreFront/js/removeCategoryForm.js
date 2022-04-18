async function removeCategoryForm(){
    if(localStorage.getItem("role") == "admin"){
        const removeCategoryViewBody =  await createSelectCategory();
        return removeCategoryViewStart + removeCategoryViewBody + removeCategoryViewEnd;
    }
            
    else
        location.href = '/';
    
}