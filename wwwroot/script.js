async function encrypt() {
  const message = document.getElementById("message").value;
  const shift = parseInt(document.getElementById("shift").value);

  const res = await fetch("/encrypt", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ message, shift })
  });

  const data = await res.text();
  document.getElementById("result").innerText = data;

  updateWheel(shift);
}

function updateWheel(shift) {
  const wheel = document.getElementById("wheel");
  const degrees = shift * (360 / 26);
  wheel.style.transform = `rotate(${degrees}deg)`;
}

function updateWheel() {
  const wheel = document.getElementById("wheel");
  const shift = document.getElementById("shift").value || 0;

  const degrees = shift * (360 / 26);
  if (wheel) {
    wheel.style.transform = `rotate(${degrees}deg)`;
  }
}