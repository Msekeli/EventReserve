function Header({ onAdd }) {
  return (
    <div className="mb-6 flex items-center justify-between">
      <h2 className="text-2xl font-semibold text-primary">
        Event Reservations
      </h2>

      <button
        onClick={onAdd}
        className="flex items-center gap-2 rounded-lg bg-primary px-4 py-2 text-white shadow-sm transition hover:bg-accent"
      >
        <span className="text-lg">＋</span>
        Add Reservation
      </button>
    </div>
  );
}

export default Header;
