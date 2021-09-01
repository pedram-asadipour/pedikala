const cookieName = "cart-items";

function AddProductToCart(id, name, price, image) {
    let products = $.cookie(cookieName);

    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = $("#product-count").val();

    const currentProduct = products.find(x => x.id === id);

    if (currentProduct !== undefined) {
        currentProduct.count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            UnitPrice : price,
            count,
            image
        };

        products.push(product);
    }

    $.cookie(cookieName, JSON.stringify(products), { expire: 1, path: "/" });

    UpdateCart();

    swal("عملیات با موفقیت انجام شد", "محصول با موفقیت به سبد خرید شما اضافه شد", "success");
}

function UpdateCart() {
    const cartItemCountDesktop = $("#cart_item_count_desktop");
    const cartItemCountMob = $("#cart_item_count_Mob");
    const cartItem = $("#cart_items");
    const productCount = $("#product-count");

    let products = $.cookie(cookieName);


    if (products === undefined)
        return;

    products = JSON.parse(products);

    cartItemCountDesktop.html(products.length);
    cartItemCountMob.html(products.length);
    cartItem.html('');
    productCount.val(1);

    products.forEach(x => {
        const unitPrice = new Intl.NumberFormat().format(
            parseInt(x.UnitPrice)
        );

        const product = `<div class="single-cart-item">
                                <a href="javascript:void(0)" class="remove-icon" onclick="RemoveProductInCart('${x.id}')">
                                    <i class="ion-android-close"></i>
                                </a>
                                <div class="image">
                                    <a href="#">
                                        <img src='/Uploads/${x.image}'
                                             class="img-fluid" alt="${x.name}" title="${x.name}">
                                    </a>
                                </div>
                                <div class="content">
                                    <p class="product-title">${x.name}</p>
                                    <p class="count">تعداد : ${x.count}</p>
                                    <p class="count">قیمت محصول : ${unitPrice}</p>
                                </div>
                            </div>`;

        cartItem.append(product);
    });
}

function RemoveProductInCart(id) {
    let products = $.cookie(cookieName);

    if (products === undefined)
        return;

    products = JSON.parse(products);

    const product = products.findIndex(x => x.id === id);

    products.splice(product, 1);

    $.cookie(cookieName, JSON.stringify(products), { expire: 1, path: "/" });

    UpdateCart();

    swal("عملیات با موفقیت انجام شد", "محصول با موفقیت از سبد خرید شما حذف   شد", "success");
}

function ChangeItemCardCount(id, totalPriceId, count) {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);

    const itemIndex = products.findIndex(x => x.id == id);

    products[itemIndex].count = count;

    const totalPrice = new Intl.NumberFormat().format(
        parseInt(products[itemIndex].UnitPrice) * parseInt(count)
    );

    $(`#${totalPriceId}`).html(totalPrice);

    $.cookie(cookieName, JSON.stringify(products), { expire: 1, path: "/" });

    UpdateCart();
}

$(document).ready(function() {

    UpdateCart();

});


function SetReplyMessage(value, dist, replyName) {
    $(`#${dist}`).val(value);

    $("#replayMessage").html(`
                   <div class="col-6">
                        <p class="text- font-weight-bold" id="messageReply">پاسخ به نظر ${replyName}</p>
                    </div>
                    <div>
                        <button class="btn btn-sm btn-outline-dark" type="button" onclick='UnSetReplyMessage("${dist
        }")'>لغو</button>
                    </div>`);
}

function UnSetReplyMessage(dist) {
    $(`#${dist}`).val("");

    $("#replayMessage").html("");
}