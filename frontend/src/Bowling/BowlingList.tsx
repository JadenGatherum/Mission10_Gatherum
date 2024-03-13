import { Bowlers } from "../types/Bowlers";
import { useEffect, useState } from "react";

function BowlersList() {
  const [bowlerData, setBowlerData] = useState<Bowlers[]>([]);
  useEffect(() => {
    console.log("useEffect triggered");
    const fetchBowlData = async () => {
      const rsp = await fetch("http://localhost:5143/bowling");
      const f = await rsp.json();
      console.log(f); // Log the response to the console
      setBowlerData(f);
    };
    fetchBowlData();
  }, []);

  return (
    <>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>PhoneNumber</th>
          </tr>
        </thead>
        <tbody>
          {bowlerData.map((b, index) => (
            <tr key={index}>
              <td>
                {b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}
              </td>
              <td>{b.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlersList;
