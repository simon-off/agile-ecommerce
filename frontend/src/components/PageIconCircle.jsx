export default function PageIconCircle({ icon, diameter, color }) {
  return (
    <div className="page-icon-circle">
      <div
        style={{
          "--diameter": `${diameter ? `${diameter}px` : ""}`,
          "--color": color,
          "--icon-color": color,
        }}
        className="circle"
      >
        {icon}
      </div>
    </div>
  );
}
