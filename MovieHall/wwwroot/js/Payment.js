const cartItems = @Html.Raw(Json.Serialize(Model));

function renderCart() {
    const cartContainer = document.getElementById('cart-items');
    cartContainer.innerHTML = '';
    cartItems.forEach(item => {
        const itemElement = document.createElement('div');
        itemElement.className = 'item';
        itemElement.dataset.id = item.id;

        let quantityControl;
        if (item.name === "Bilet") {
            quantityControl = `<span>${item.quantity}</span>`;
        } else {
            quantityControl = `
                        <button data-id="${item.id}" class="decrease">-</button>
                        <span>${item.quantity}</span>
                        <button data-id="${item.id}" class="increase">+</button>
                    `;
        }

        itemElement.innerHTML = `
                    <div class="item-info">
                        <img src="${item.image}" alt="${item.name}" class="item-image">
                        <span>${item.name} (${item.price} TL)</span>
                    </div>
                    <div class="quantity-control">
                        ${quantityControl}
                        <span>${item.price * item.quantity} TL</span>
                    </div>
                `;
        cartContainer.appendChild(itemElement);
    });
    updateTotal();
}

function updateQuantity(id, increment) {
    const item = cartItems.find(item => item.id === id);
    if (item && item.name !== "Bilet") {
        if (increment) {
            item.quantity++;
        } else {
            item.quantity = Math.max(0, item.quantity - 1);
        }
        renderCart();
    }
}

function updateTotal() {
    const total = cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);
    document.getElementById('total-amount').textContent = total;
}

document.getElementById('cart-items').addEventListener('click', function (e) {
    if (e.target.matches('button')) {
        const id = parseInt(e.target.dataset.id);
        const increment = e.target.classList.contains('increase');
        updateQuantity(id, increment);
    }
});

document.getElementById('payment-form').addEventListener('submit', function (e) {
    e.preventDefault();
    document.getElementById('payment-error').style.display = 'block';
});

renderCart();