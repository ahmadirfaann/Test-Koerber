// Simple toast helper for Blazor/JS interop
window.showToast = (message, type = "info") => {
  try {
    const toastContainerId = "blazor-toast-container";
    let container = document.getElementById(toastContainerId);

    if (!container) {
      container = document.createElement("div");
      container.id = toastContainerId;
      container.style.position = "fixed";
      container.style.bottom = "1.5rem";
      container.style.right = "1.5rem";
      container.style.zIndex = "1080";
      container.style.display = "flex";
      container.style.flexDirection = "column";
      container.style.gap = "0.75rem";
      document.body.appendChild(container);
    }

    const toast = document.createElement("div");
    toast.textContent = message;
    toast.setAttribute("role", "status");
    toast.style.padding = "0.75rem 1.25rem";
    toast.style.borderRadius = "999px";
    toast.style.fontWeight = "600";
    toast.style.boxShadow = "0 10px 30px rgba(0, 0, 0, 0.15)";
    toast.style.transition = "opacity 0.4s ease";
    toast.style.opacity = "0";
    toast.style.color = "#fff";

    const backgroundMap = {
      success: "linear-gradient(135deg, #11998e 0%, #38ef7d 100%)",
      danger: "linear-gradient(135deg, #f093fb 0%, #f5576c 100%)",
      warning: "linear-gradient(135deg, #fa709a 0%, #fee140 100%)",
      info: "linear-gradient(135deg, #667eea 0%, #764ba2 100%)"
    };

    toast.style.background = backgroundMap[type] ?? backgroundMap.info;

    container.appendChild(toast);

    // Trigger fade-in on next frame so the transition runs
    requestAnimationFrame(() => {
      toast.style.opacity = "1";
    });

    // Remove toast after delay
    setTimeout(() => {
      toast.style.opacity = "0";
      toast.addEventListener(
        "transitionend",
        () => {
          toast.remove();
          if (container.childElementCount === 0) {
            container.remove();
          }
        },
        { once: true }
      );
    }, 2500);
  } catch (error) {
    console.warn("showToast fallback:", error);
    alert(message);
  }
};
