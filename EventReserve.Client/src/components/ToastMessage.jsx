function ToastMessage({ message, type = "success" }) {
  const styles =
    type === "success"
      ? "border-emerald-200 bg-emerald-50 text-emerald-700"
      : "border-red-200 bg-red-50 text-red-700";

  return (
    <div
      className={`fixed right-6 top-6 z-50 rounded-xl border px-4 py-3 shadow-lg ${styles}`}
    >
      <p className="text-sm font-medium">{message}</p>
    </div>
  );
}

export default ToastMessage;
