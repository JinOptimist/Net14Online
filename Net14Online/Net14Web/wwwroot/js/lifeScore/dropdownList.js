if (document.querySelector(".drop")) {
	const lists = document.querySelectorAll(".drop");
	dropList(lists);

	function dropList(els) {
		els.forEach((el) => {
			el.addEventListener("click", (e) => {
				e.currentTarget.classList.toggle("show");
				let content = e.currentTarget.nextElementSibling;
				if (content.style.maxHeight) {
					content.style.maxHeight = null;
				} else {
					content.style.maxHeight = content.scrollHeight + "px";
				}
			});
		});
	}
}