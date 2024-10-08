document.getElementById("save-text-btn").addEventListener("click", () => {
  const editor = document.getElementById("text-editor");
  const newText = editor.value;

  fetch("/saveText", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ text: newText })
  })
});

document.getElementById("clear-text-btn").addEventListener("click", () => {
  fetch("/clearText", { method: "POST" }).then(() => updateEditor());
});

document.getElementById("undo-btn").addEventListener("click", () => {
  fetch("/undo", { method: "POST" }).then(() => updateEditor());
});

document.getElementById("redo-btn").addEventListener("click", () => {
  fetch("/redo", { method: "POST" }).then(() => updateEditor());
});

function updateEditor() {
  fetch("/getText")
    .then(response => response.json())
    .then(data => {
      document.getElementById("text-editor").value = data.text;
    });
}

// Initial load
updateEditor();