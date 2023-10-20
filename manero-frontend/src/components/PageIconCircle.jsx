/**
 * @param {ReactNode} icon Icon to be displayed in circle
 * @param {number} diameter The diameter of the circle
 * @param {string} color The color of the icon and outer circle
 */
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
