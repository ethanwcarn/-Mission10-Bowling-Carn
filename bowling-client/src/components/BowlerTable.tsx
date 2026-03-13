import { useEffect, useState } from 'react'

/**
 * Shape of a single bowler row returned from the ASP.NET API.
 * These property names match the BowlerDto type defined on the server.
 */
export interface Bowler {
  bowlerName: string
  teamName: string
  address: string
  city: string
  state: string
  zip: string
  phoneNumber: string
}

/**
 * URL of the ASP.NET API endpoint that exposes bowler data.
 * If the API port changes, this constant is the only place that must be updated.
 */
const API_URL = '/api/bowlers'

/**
 * Table component that fetches bowler data from the ASP.NET API and
 * renders the required fields in a clean, readable layout.
 */
export function BowlerTable() {
  // Local state for the downloaded bowler list.
  const [bowlers, setBowlers] = useState<Bowler[]>([])

  // Local state used to show basic loading and error feedback to the user.
  const [isLoading, setIsLoading] = useState<boolean>(true)
  const [errorMessage, setErrorMessage] = useState<string | null>(null)

  useEffect(() => {
    /**
     * Fetches bowler data from the API and updates component state.
     * This function is defined inside useEffect so that it only runs on mount.
     */
    const loadBowlers = async () => {
      try {
        setIsLoading(true)
        setErrorMessage(null)

        const response = await fetch(API_URL)

        if (!response.ok) {
          throw new Error(`Request failed with status ${response.status}`)
        }

        const data: Bowler[] = await response.json()
        setBowlers(data)
      } catch (error) {
        // Store a friendly error message so something helpful is shown in the UI.
        setErrorMessage(
          'Unable to load bowler data from the server. Please verify that the ASP.NET API is running.'
        )
        // In a real application we might also log the error for diagnostics.
        console.error('Error loading bowlers', error)
      } finally {
        setIsLoading(false)
      }
    }

    loadBowlers()
  }, [])

  if (isLoading) {
    // Render a simple loading state while data is being fetched.
    return <p className="status-message">Loading bowlers…</p>
  }

  if (errorMessage) {
    // Render a friendly error state if the fetch operation fails.
    return <p className="status-message status-error">{errorMessage}</p>
  }

  return (
    <section className="table-section">
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler) => (
            <tr key={`${bowler.teamName}-${bowler.bowlerName}-${bowler.phoneNumber}`}>
              <td>{bowler.bowlerName}</td>
              <td>{bowler.teamName}</td>
              <td>{bowler.address}</td>
              <td>{bowler.city}</td>
              <td>{bowler.state}</td>
              <td>{bowler.zip}</td>
              <td>{bowler.phoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </section>
  )
}

