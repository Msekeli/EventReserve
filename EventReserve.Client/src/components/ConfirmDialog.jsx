function ConfirmDialog({ title, message, onConfirm, onCancel }) {
  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/40 px-4">
      <div className="w-full max-w-md rounded-2xl border border-red-100 bg-white p-6 shadow-xl">
        <div className="mb-4">
          <h2 className="text-xl font-semibold text-red-600">{title}</h2>
          <p className="mt-2 text-sm text-slate-600">{message}</p>
        </div>

        <div className="flex justify-end gap-3">
          <button
            type="button"
            onClick={onCancel}
            className="cursor-pointer rounded-lg border border-slate-300 px-4 py-2 text-slate-700 transition hover:bg-slate-100"
          >
            Cancel
          </button>

          <button
            type="button"
            onClick={onConfirm}
            className="cursor-pointer rounded-lg bg-red-600 px-4 py-2 text-white transition hover:bg-red-700"
          >
            Delete
          </button>
        </div>
      </div>
    </div>
  );
}

export default ConfirmDialog;
