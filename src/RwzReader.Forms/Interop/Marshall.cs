using System.Runtime.InteropServices;

using InteropServicesMarshal = System.Runtime.InteropServices.Marshal;

namespace RwzReader.Forms.Interop;

internal static class Marshal
{
    /// <summary>
    /// Retrieves a running COM object that is registered in the Running Object Table (ROT) by its ProgID.
    /// </summary>
    /// <param name="progId">The programmatic identifier (ProgID) of the COM object to retrieve.</param>
    /// <returns>
    /// A reference to the active COM object if successful; otherwise, <c>null</c> if <paramref name="throwOnError"/> is <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="progId"/> is <c>null</c>.</exception>
    /// <exception cref="COMException">Thrown when a COM error occurs if <paramref name="throwOnError"/> is <c>true</c>.</exception>
    /// <remarks>
    /// This method attempts to retrieve an already running instance of the specified COM server
    /// rather than creating a new instance.
    /// </remarks>
    public static object? GetActiveObject(string progId) => GetActiveObject(progId, true);

    /// <param name="throwOnError">When set to <c>true</c>, the method throws an exception if an error occurs; 
    /// otherwise, it returns <c>null</c>. The default value is <c>true</c>.</param>
    /// <inheritdoc cref="GetActiveObject(string)"/>
    public static object? GetActiveObject(string progId, bool throwOnError = true)
    {
        ArgumentNullException.ThrowIfNull(progId);

        int hResult = CLSIDFromProgIDEx(progId, out Guid clsid);
        if (hResult < 0)
        {
            if (throwOnError)
            {
                InteropServicesMarshal.ThrowExceptionForHR(hResult);
            }

            return null;
        }

        hResult = GetActiveObject(clsid, nint.Zero, out object? obj);
        if (hResult < 0)
        {
            if (throwOnError)
            {
                InteropServicesMarshal.ThrowExceptionForHR(hResult);
            }

            return null;
        }

        return obj;
    }

    [DllImport("ole32")]
    private static extern int CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid lpclsid);

    [DllImport("oleaut32")]
    private static extern int GetActiveObject([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid, nint pvReserved, [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
}