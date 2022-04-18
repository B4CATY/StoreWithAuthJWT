async function createDropDownCategories(){

    const categories = await GetCategories();
    let categoriessHtml = "";
    for (const category of categories) {
        categoriessHtml += liDropDownCategories(category);
    }

    const categoriesDopDown = document.querySelector('.dropdowns-child');
    categoriesDopDown.innerHTML = categoriessHtml;
}

async function createVideoCartTableById(id){

    const vTableBody = await GetVideoCartsByCategories(id);
    //console.log(vTableBody);
    const table = vTableStart  + vTableBody + vTableEnd 
         //+ paginationHtml
         + divEnd;
     
     //pagination_start(id, 'categories');
     
    return table;
  }

  function liDropDownCategories(category){
    return `<a role="button" class="nav-item p-3  text-start text-white"
    onclick="router.loadRoute('categories', '${category.id}')">
      ${category.name}</a>`;
}