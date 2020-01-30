using System;
using System.Text;

namespace Flight_Project
{

public class Flight {
	private String airLineName;
	private City originCity;
	private City destinationCity;
	private String flightNumber;
	
	/**
	 * Empty-argument constructor to put 
	 * the object into a consistent state.
	 */
	public Flight() {
		airLineName= null;
		originCity = null;
		destinationCity = null;
		flightNumber = null;
	}//end constructor
	
	/**
	 * Preferred constructor for this object
	 * @param aln - airline number
	 * @param fn - flight number
	 * @param o - origin city
	 * @param d - destination city
	 */
	public Flight(String aln, String fn, City o, City d) {
		
		setAirLineName(aln);
		setFlightNumber(fn);
		setOriginCity(o);
		setDestinationCity(d);
		
	}//end constructor
	
	/**
	 * Method uses the haversine formulae
	 * to calculate the distance around the 
	 * globe from one city to another.
	 * @return - distance in miles
	 */
	public double calcDistanceToFly() {
		
		double R = 6371000;
		double lat1 = originCity.getLatitude();
		double lat2 = destinationCity.getLatitude();
		double lon1 = originCity.getLongitude();
		double lon2 = destinationCity.getLongitude();
		
		double lat1Radians = ToRadians(lat1);
		double lat2Radians = ToRadians(lat2);
		double lon1Radians = ToRadians(lon1);
		double lon2Radians = ToRadians(lon2);

		double deltaLat = ToRadians(lat2-lat1);
		double deltaLon = ToRadians(lon2-lon1);
		
		double a = Math.Pow(Math.Sin(deltaLat/2),2) + Math.Cos(lat1Radians) * Math.Cos(lat2Radians)*Math.Pow(Math.Sin(deltaLon/2),2);
		
		double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
		
		double distance = R * c;
		
		return distance * 0.000621371;
	}//end 
	
	/**
	 * This method will return all of the flight
	 * details including the airline, flight number,
	 * and distance between two city objects.
	 * @return -String representing the flight details
	 */
	public String printFlightDetails() {
		
		
		
		StringBuilder sb = new StringBuilder();
		
		sb.Append(airLineName + " " + flightNumber +"\n");
		sb.Append(originCity.getName() + " to " + destinationCity.getName()+"\n");
		sb.Append("Distance: " + (this.calcDistanceToFly()).ToString("N3") + " miles.\n");
			
		return sb.ToString();
	}//end printFlightDetails

	/**
	 * getter for airLineName
	 * @return
	 */
	public String getAirLineName() {
		return airLineName;
	}//end getAirline

	/**
	 * Setter for airLineName
	 * @param airLineName
	 */
	public void setAirLineName(String airLineName) {
		this.airLineName = airLineName;
	}//end setAirLineName

	/**
	 * Getter for flightNumber
	 * @return
	 */
	public String getFlightNumber() {
		return flightNumber;
	}//end getFlightNumber

	/**
	 * Setter for flightNumber
	 * @param flightNumber
	 */
	public void setFlightNumber(String flightNumber) {
		this.flightNumber = flightNumber;
	}//end setFlightNumber
	
	/**
	 * Getter for originCity
	 * @return
	 */
	public City getOriginCity() {
		return originCity;
	}//end getOriginCity

	/**
	 * Setter for originCity
	 * @param originCity
	 */
	public void setOriginCity(City originCity) {
		this.originCity = originCity;
	}//end setOriginCity

	/**
	 * Getter for destinationCity
	 * @return
	 */
	public City getDestinationCity() {
		return destinationCity;
	}//end getDestinationCity

	/**
	 * Setter for destinationCity
	 * @param destinationCity
	 */
	public void setDestinationCity(City destinationCity) {
		this.destinationCity = destinationCity;
	}//end setDestinationCity

	public double ToRadians(double val)
    {
        return (Math.PI / 180) * val;
    }

	public String toString() {
		return "Flight [airLineName=" + airLineName + ", originCity=" + originCity + ", destinationCity="
				+ destinationCity + ", flightNumber=" + flightNumber + "]";
	}//end toString

	
}//end class
}
