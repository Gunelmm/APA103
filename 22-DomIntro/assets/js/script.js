document.body.style.margin = "0";
document.body.style.height = "100vh";
document.body.style.display = "flex";
document.body.style.justifyContent = "center";
document.body.style.alignItems = "center";
document.body.style.background = "#f5f5f5";
document.body.style.fontFamily = "Arial";

const data = {
  image: "https://images.unsplash.com/photo-1568605114967-8130f3a36994",
  type: "DETACHED HOUSE • 5Y OLD",
  price: "$750,000",
  address: "742 Evergreen Terrace",
  bedrooms: 3,
  bathrooms: 2,
  realtor: {
    name: "Tiffany Heffner",
    phone: "(555) 555-4321",
    avatar: "https://randomuser.me/api/portraits/women/44.jpg"
  }
};

const card = document.createElement("div");
card.style.width = "350px";
card.style.borderRadius = "12px";
card.style.background = "#fff";
card.style.position = "relative";

const heart = document.createElement("i");
heart.className = "fa-regular fa-heart";
heart.style.position = "absolute";
heart.style.top = "10px";
heart.style.right = "15px";
heart.style.fontSize = "24px";
heart.style.color = "white";
heart.style.cursor = "pointer";
heart.style.textShadow = "0 0 5px black";

heart.addEventListener("click", () => {
  if (heart.classList.contains("fa-regular")) {
    heart.classList.remove("fa-regular");
    heart.classList.add("fa-solid");
    heart.style.color = "red";
  } else {
    heart.classList.remove("fa-solid");
    heart.classList.add("fa-regular");
    heart.style.color = "white";
  }
});

const img = document.createElement("img");
img.src = data.image;
img.style.width = "100%";
img.style.height = "220px";
img.style.objectFit = "cover";

const body = document.createElement("div");
body.style.padding = "15px";

const type = document.createElement("div");
type.textContent = data.type;
type.style.color = "black";
type.style.fontWeight = "bold";
type.style.fontSize = "14px";

const price = document.createElement("div");
price.textContent = data.price;
price.style.fontSize = "28px";
price.style.margin = "5px 0";

const address = document.createElement("div");
address.textContent = data.address;
address.style.color = "#746e6e";

const room = document.createElement("div");
room.style.display = "flex";
room.style.justifyContent = "space-between";
room.style.margin = "15px 0";

const bed = document.createElement("span");
bed.textContent = data.bedrooms + " Bedrooms";
bed.style.color = "#746e6e";

const bath = document.createElement("span");
bath.textContent = data.bathrooms + " Bathrooms";
bath.style.color = "#746e6e";

room.appendChild(bed);
room.appendChild(bath);

const realtor = document.createElement("div");
realtor.style.borderTop = "1px solid #eee";
realtor.style.paddingTop = "10px";
realtor.style.display = "flex";
realtor.style.alignItems = "center";

const avatar = document.createElement("img");
avatar.src = data.realtor.avatar;
avatar.style.width = "40px";
avatar.style.height = "40px";
avatar.style.borderRadius = "50%";
avatar.style.marginRight = "10px";

const info = document.createElement("div");

const realtorName = document.createElement("div");
realtorName.textContent = data.realtor.name;
realtorName.style.fontWeight = "bold";

const phone = document.createElement("div");
phone.textContent = data.realtor.phone;
phone.style.color = "gray";

info.appendChild(realtorName);
info.appendChild(phone);

realtor.appendChild(avatar);
realtor.appendChild(info);

body.appendChild(type);
body.appendChild(price);
body.appendChild(address);
body.appendChild(room);
body.appendChild(realtor);

card.appendChild(img);
card.appendChild(heart);
card.appendChild(body);

document.body.appendChild(card);