function displayStatus(isOk, text) {
    const statusDiv = document.getElementById("statusMessages");
    const statusText = document.createElement("h1");
    statusDiv.style.color = isOk ? "03d3b2" : "red";
    statusText.innerHTML = text;
    statusDiv.append(statusText);
  }
document.querySelector("form").addEventListener("submit", (e) => {
  e.preventDefault();
  const image = document.getElementById("img").value;
  const price = document.getElementById("price").value;
  const description = document.getElementById("saleDescription").value;
  const city = document.getElementById("saleCity").value;

  const houses = {
    image: image,
    city: city,
    price: price,
    description: description,
  };
  document.getElementById("statusMessages").innerHTML = "";
  fetch("https://localhost:7299/Homes", {
    method: "POST",
    body: JSON.stringify(houses),
    headers: {
      Accept: "text/json",
      "Content-Type": "application/json",
    },
     })
  .then((res) => {
           if (res.ok) {
             displayStatus(res.ok, "Property successfully added.");
           } else {
            throw new Error(res.statusText);
           }
         })
         .catch((error) => {
           displayStatus(false, `Something went wrong. Server returned: ${error}.`);
         });
});