import {Product} from "./class.js"

let product1 = new Product("1060Ti", "MSI", 25000);
Product.setColour();




let olldHtml = `<tr class="trBody">
<td>
    <p>Catr1</p> 
</td>
<td>
    <p>Ochko</p> 
</td>
<td>
   <p>2311</p> 
</td>
</tr>`;

let newHtml =  `<tr class="trBody"><td><a>"${product1.videcart}"</a> </td>
<td><h5>${product1.category}</h5></td>
<td><h5>${product1.price}</h5></td></tr>`;

$('.tableId').css("background-color", "silver").append(newHtml);

$('a').first().prop('href', 'https://github.com/B4CATY/peeeezda/blob/main/readme');